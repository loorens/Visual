   M S B A M L   `   `   `  ����Q  MTreeViewWithCheckBoxes, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:TreeViewWithCheckBoxesTreeViewWithCheckBoxes  5      ?$clr-namespace:DrWPF.Windows.ControlsDrWPF.Windows.Controls  5      $    TreeViewWithCheckBoxes.Window1   5      \ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      8x,http://schemas.microsoft.com/winfx/2006/xaml    5      4local$clr-namespace:TreeViewWithCheckBoxes    5      1dw$clr-namespace:DrWPF.Windows.Controls    5      $��13(�5        � Title$  TreeView with CheckBoxes��5      $	��300��5	      $	��300��6    � WindowStartupLocation$ CenterScreen=�5
       � 	Resources 5       �� MergedDictionaries �� Source   TreeViewItemStyle �� 
TargetType �� Property �� Value �� Mode-  'System.Windows.Input.KeyboardNavigation0   *DrWPF.Windows.Controls.VirtualToggleButton  CheckBoxItemTemplate	 �� ItemsSource
 �� Orientation d� 	IsChecked�� 5       5      �� 5   
   $f `/PresentationFramework.Royale;V3.0.0.0;31bf3856ad364e35;component\themes\royale.normalcolor.xaml?�6   %|  &	        &	 J    �� 5      " Q�6(   .�5   
   ��  �@Q�
IsExpanded . 6'   �� 5   
    �@Q�
IsSelected 6'   �� *IsInitiallySelected+$ OneTime=��� 5   
    �@ AcceptsReturn . 6=   �� 5   
    �@ IsVirtualToggleButton . 6I   �� 5   
    �@ 	IsChecked 6=   �� *	IsChecked+5   	   �� 5      	 5   	   �� *
Children+$ OneTime=�.R�5   
   �� $
 
Horizontal=�6   .+�5!      �� |�.  $��Center=�5$       5#      �� *	IsChecked+5$      �� 5&      $	��2,0q�5(      ��5'      �� *Name+$ OneTime=�5(      5*      5+   	   5,       � DataContext 5/      S� 50       S� 
MethodName$ 
CreateFoos��51       S� 
ObjectType)   #TreeViewWithCheckBoxes.FooViewModel"  52      .��55      ]� .+�56      �� $��Bottom=�57      $
��Undo��58      $��Uncheck All��59      $��Center=�5:      $	��0,2q�5;      $	��8,0q�5<      R� 5>      -   5         R�Name$
 tree��5?      #��[  5@      #��[ 5B      ��5A      �� $ OneTime=�5B      5D      5E      