﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuFX
{
    public partial class SudokuBoard
    {
        
    }
    public class Cell : INotifyPropertyChanged 
    {   
        public Cell(int maxval)
        {
            possibleValuesValue = new ObservableCollection<int?>();
            possibleValuesValue.Add(null);
            for (int i = 1; i <= maxval; i++)
            {
                possibleValuesValue.Add(i);
            }
        }
        
        private bool readOnlyValue = false;
        private int? valueValue = null;
        private bool isValidValue = true;
        private ObservableCollection<int?> possibleValuesValue;
        public bool ReadOnly
        {
            get { return readOnlyValue; }
            set { if(readOnlyValue != value )
                    {
                        readOnlyValue = value;
                        if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("ReadOnly"));
                    }
                }
        }

        public int? Value
        {
            get { return valueValue; }
            set
            {
                if (valueValue != value)
                {
                    valueValue = value;
                    if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("Value"));
                }
            }
        }

        public bool IsValid
        {
            get { return isValidValue; }
            set
            {
                if (isValidValue != value)
                {
                    isValidValue = value;
                    if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("IsValid"));
                }
            }
        }
        public ObservableCollection<int?> PossibleValues
        {
            get { return possibleValuesValue; }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }

    public class InnerGrid : INotifyPropertyChanged
    {
        private ObservableCollection<ObservableCollection<Cell>> Rows;
        public ObservableCollection<ObservableCollection<Cell>> GridRows
        {
            get {return Rows;}
        }

        public InnerGrid(int size)
        {
            Rows = new ObservableCollection<ObservableCollection<Cell>>();
            for (int i = 0; i < size; i++)
            {
                ObservableCollection<Cell> Col = new ObservableCollection<Cell>();
                for (int j = 0; j < size; j++)
                {
                    Cell c = new Cell(size * size);
                    c.PropertyChanged += new PropertyChangedEventHandler(c_PropertyChanged);
                    Col.Add(c);
                }
                Rows.Add(Col);
            }
        }

        void c_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Value" )
            {
                bool valid = CheckIsValid();
                foreach (ObservableCollection<Cell> R in Rows)
                {
                    foreach (Cell C in R)
                    {
                        C.IsValid = valid;
                    }
                }
                isValidValue = valid;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("IsValid"));
            }
        }
        private bool isValidValue = true;
        public bool IsValid
        {
            get { return isValidValue; }
        }

        private bool CheckIsValid()
        {
            bool[] used = new bool[Rows.Count * Rows.Count];
            foreach (ObservableCollection<Cell> R in Rows)
            {
                foreach (Cell C in R)
                {
                    if(C.Value.HasValue)
                    {
                        if(used[C.Value.Value-1])
                        {
                            return false; //
                        }
                        else
                        {
                            used[C.Value.Value - 1] = true;
                        }
                    }
                }
            }
            return true;
        }

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        public Cell this[int row, int col]
        {
            get
            {
                if (row < 0 || row > Rows.Count) throw new ArgumentOutOfRangeException("row", row, "Invalid row index");
                if (col < 0 || col > Rows.Count) throw new ArgumentOutOfRangeException("col", col, "Invalid col index");
                return Rows[row][col];
            }

        }
    }
    public class Board : INotifyPropertyChanged
    {
        private ObservableCollection<ObservableCollection<InnerGrid>> Rows;
        public ObservableCollection<ObservableCollection<InnerGrid>> GridRows
        {
            get { return Rows; }
        }
        public Board(int totalsize)
        {
            int size = (int)Math.Sqrt(totalsize);
            Rows = new ObservableCollection<ObservableCollection<InnerGrid>>();
            for (int i = 0; i < size; i++)
            {
                ObservableCollection<InnerGrid> Col = new ObservableCollection<InnerGrid>();
                for (int j = 0; j < size; j++)
                {
                    InnerGrid g = new InnerGrid(size);
                    g.PropertyChanged += new PropertyChangedEventHandler(g_PropertyChanged);
                    Col.Add(g);
                }
                Rows.Add(Col);
            }
        }

        private void g_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "IsValid")
            {
                bool valid = true;
                int totalsize = Rows.Count * Rows.Count;
                for (int i = 0; i < totalsize; i++)
                {
                    bool rowValid = CheckRowIsValid(i);
                    for (int j = 0; j < totalsize; j++)
                    {
                        bool innerGridValid = Rows[i / Rows.Count][j / Rows.Count].IsValid;
                        this[i, j].IsValid = rowValid & innerGridValid;
                    }
                    bool colValid = CheckColumnIsValid(i);
                    for (int j = 0; j < totalsize; j++)
                    {
                        bool innerGridValid = Rows[i / Rows.Count][j / Rows.Count].IsValid;
                        this[j, i].IsValid = rowValid & innerGridValid;
                    }   
                }
                isValidValue = valid;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("IsValid"));

            }
        }
        bool isValidValue = true;
        public bool IsValid
        {
            get
            {
                return isValidValue;
            }
        }
        private bool CheckColumnIsValid(int row)
        {
            int width = Rows.Count * Rows.Count;
            bool[] used = new bool[width];
            for (int i = 0; i < width; i++)
            {
                Cell c = this[row, i];
                if(c.Value.HasValue)
                {
                    if(used[c.Value.Value-1])
                    {
                        return false;
                    }
                    else
                    {
                        used[c.Value.Value - 1] = true;
                    }
                }
            }
            return true;
        }

        private bool CheckRowIsValid(int col)
        {
            int height = Rows.Count * Rows.Count;
            bool[] used = new bool[height];
            for (int i = 0; i < height; i++)
            {
                Cell c = this[i, col];
                if (c.Value.HasValue)
                {
                    if (used[c.Value.Value - 1])
                    {
                        return false;
                    }
                    else
                    {
                        used[c.Value.Value - 1] = true;
                    }
                }
            }
            return true;
        }

        public Cell this[int row, int col]
        {
            get
            {
                int totalsize = Rows.Count * Rows.Count;
                if (row < 0 || row > totalsize) throw new ArgumentOutOfRangeException("row", row, "invalid row index");
                if (col < 0 || col > totalsize) throw new ArgumentOutOfRangeException("col", col, "invalid col index");
                return Rows[row / Rows.Count][col / Rows.Count][row % Rows.Count, col % Rows.Count];
            }
        }
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
    
}
