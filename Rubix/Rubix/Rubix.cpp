#include "stdafx.h"
#include <time.h>
#include <stdlib.h>
#include <conio.h>
#include <string>
using std::string;
struct rubix
{
	char wall[9];
};
int licznik = 0;
rubix kostka[6];
rubix kopia[6];
string moves = "";
void Obrot(int, int);
void ObrotZnak(char, int);
void start()
{
	for (int  i = 0; i < 6; i++)
	{
		for (int j = 0; j < 9; j++)
		{
			kostka[i].wall[j] = i;
		}
	}
}

void start2()
{
	for (int i = 0; i < 6; i++)
	{
		for (int j = 0; j < 9; j++)
		{
			kostka[i].wall[j] = j;
		}
	}
}
void Random(int n)
{
	srand((unsigned)time(NULL));
	int r = (rand() % 6);
	for (int i = 0; i < n; i++)
	{
		r = (rand() % 6);
		Obrot(r, 0);
	}
}

void Wypisz(rubix *kostka)
{
	for (int i = 0; i < 3; i++)
	{
		printf("      ");
		for (int  j = 0; j < 3; j++)
		{
			printf("%d ", kostka[4].wall[i * 3 + j]);
		}
		printf("\n");
	}
	for (int i = 0; i < 3; i++)
	{
		for (int j = 0; j < 4; j++)
		{
			for (int  k = 0; k < 3; k++)
			{
				printf("%d ", kostka[j].wall[i * 3 + k]);
			}
		}
		printf("\n");
	}
	for (int i = 0; i < 3; i++)
	{
		printf("      ");
		for (int j = 0; j < 3; j++)
		{
			printf("%d ", kostka[5].wall[i * 3 + j]);
		}
		printf("\n");
	}
	printf("--------------------------------------\n");
}
void Kopiuj(rubix * from, rubix * to)
{
	for (int i = 0; i < 6; i++)
	{
		for (int j = 0; j < 9; j++)
		{
			to[i].wall[j] = from[i].wall[j];
		}
	}
}
void ObrotSciany(int n)
{
	kopia[n].wall[0] = kostka[n].wall[6];
	kopia[n].wall[1] = kostka[n].wall[3];
	kopia[n].wall[2] = kostka[n].wall[0];
	kopia[n].wall[3] = kostka[n].wall[7];
	kopia[n].wall[5] = kostka[n].wall[1];
	kopia[n].wall[6] = kostka[n].wall[8];
	kopia[n].wall[7] = kostka[n].wall[5];
	kopia[n].wall[8] = kostka[n].wall[2];
	Kopiuj(kopia, kostka);
}
void Obrot(int n, int wypisz = 0)
{
	Kopiuj(kostka, kopia);
	ObrotSciany(n);
	if (n == 0) // L
	{
		kopia[1].wall[0] = kostka[4].wall[0];
		kopia[1].wall[3] = kostka[4].wall[3];
		kopia[1].wall[6] = kostka[4].wall[6];
		kopia[5].wall[0] = kostka[1].wall[0];
		kopia[5].wall[3] = kostka[1].wall[3];
		kopia[5].wall[6] = kostka[1].wall[6];
		kopia[3].wall[2] = kostka[5].wall[6];
		kopia[3].wall[5] = kostka[5].wall[3];
		kopia[3].wall[8] = kostka[5].wall[0];
		kopia[4].wall[0] = kostka[3].wall[8];
		kopia[4].wall[3] = kostka[3].wall[5];
		kopia[4].wall[6] = kostka[3].wall[2];
	}
	else if (n == 1) // F
	{
		kopia[2].wall[0] = kostka[4].wall[6];
		kopia[2].wall[3] = kostka[4].wall[7];
		kopia[2].wall[6] = kostka[4].wall[8];
		kopia[5].wall[0] = kostka[2].wall[6];
		kopia[5].wall[1] = kostka[2].wall[3];
		kopia[5].wall[2] = kostka[2].wall[0];
		kopia[0].wall[8] = kostka[5].wall[2];
		kopia[0].wall[5] = kostka[5].wall[1];
		kopia[0].wall[2] = kostka[5].wall[0];
		kopia[4].wall[6] = kostka[0].wall[8];
		kopia[4].wall[7] = kostka[0].wall[5];
		kopia[4].wall[8] = kostka[0].wall[2];
	}
	else if (n == 2) // R
	{
		kopia[3].wall[0] = kostka[4].wall[8];
		kopia[3].wall[3] = kostka[4].wall[5];
		kopia[3].wall[6] = kostka[4].wall[2];
		kopia[5].wall[2] = kostka[3].wall[6];
		kopia[5].wall[5] = kostka[3].wall[3];
		kopia[5].wall[8] = kostka[3].wall[0];
		kopia[1].wall[2] = kostka[5].wall[2];
		kopia[1].wall[5] = kostka[5].wall[5];
		kopia[1].wall[8] = kostka[5].wall[8];
		kopia[4].wall[2] = kostka[1].wall[2];
		kopia[4].wall[5] = kostka[1].wall[5];
		kopia[4].wall[8] = kostka[1].wall[8];
	}
	else if (n == 3) // B
	{
		kopia[2].wall[2] = kostka[5].wall[8];
		kopia[2].wall[5] = kostka[5].wall[7];
		kopia[2].wall[8] = kostka[5].wall[6];
		kopia[5].wall[8] = kostka[0].wall[6];
		kopia[5].wall[7] = kostka[0].wall[3];
		kopia[5].wall[6] = kostka[0].wall[0];
		kopia[0].wall[6] = kostka[4].wall[0];
		kopia[0].wall[3] = kostka[4].wall[1];
		kopia[0].wall[0] = kostka[4].wall[2];
		kopia[4].wall[0] = kostka[2].wall[2];
		kopia[4].wall[1] = kostka[2].wall[5];
		kopia[4].wall[2] = kostka[2].wall[8];
	}
	else if (n == 4) // U
	{
		kopia[0].wall[0] = kostka[1].wall[0];
		kopia[0].wall[1] = kostka[1].wall[1];
		kopia[0].wall[2] = kostka[1].wall[2];
		kopia[1].wall[0] = kostka[2].wall[0];
		kopia[1].wall[1] = kostka[2].wall[1];
		kopia[1].wall[2] = kostka[2].wall[2];
		kopia[2].wall[0] = kostka[3].wall[0];
		kopia[2].wall[1] = kostka[3].wall[1];
		kopia[2].wall[2] = kostka[3].wall[2];
		kopia[3].wall[0] = kostka[0].wall[0];
		kopia[3].wall[1] = kostka[0].wall[1];
		kopia[3].wall[2] = kostka[0].wall[2];
	}
	else if (n == 5) // D
	{
		kopia[0].wall[6] = kostka[3].wall[6];
		kopia[0].wall[7] = kostka[3].wall[7];
		kopia[0].wall[8] = kostka[3].wall[8];
		kopia[1].wall[6] = kostka[0].wall[6];
		kopia[1].wall[7] = kostka[0].wall[7];
		kopia[1].wall[8] = kostka[0].wall[8];
		kopia[2].wall[6] = kostka[1].wall[6];
		kopia[2].wall[7] = kostka[1].wall[7];
		kopia[2].wall[8] = kostka[1].wall[8];
		kopia[3].wall[6] = kostka[2].wall[6];
		kopia[3].wall[7] = kostka[2].wall[7];
		kopia[3].wall[8] = kostka[2].wall[8];
	}
	else if (n == 10) //X
	{
		ObrotSciany(2);
		ObrotSciany(0);
		ObrotSciany(0);
		ObrotSciany(0);

		kopia[4] = kostka[1];
		kopia[1] = kostka[5];
		//kopia[5] = kostka[3];
		//kopia[3] = kostka[4];
		kopia[5].wall[0] = kostka[3].wall[8];
		kopia[5].wall[1] = kostka[3].wall[7];
		kopia[5].wall[2] = kostka[3].wall[6];
		kopia[5].wall[3] = kostka[3].wall[5];
		kopia[5].wall[4] = kostka[3].wall[4];
		kopia[5].wall[5] = kostka[3].wall[3];
		kopia[5].wall[6] = kostka[3].wall[2];
		kopia[5].wall[7] = kostka[3].wall[1];
		kopia[5].wall[8] = kostka[3].wall[0];

		kopia[3].wall[0] = kostka[4].wall[8];
		kopia[3].wall[1] = kostka[4].wall[7];
		kopia[3].wall[2] = kostka[4].wall[6];
		kopia[3].wall[3] = kostka[4].wall[5];
		kopia[3].wall[4] = kostka[4].wall[4];
		kopia[3].wall[5] = kostka[4].wall[3];
		kopia[3].wall[6] = kostka[4].wall[2];
		kopia[3].wall[7] = kostka[4].wall[1];
		kopia[3].wall[8] = kostka[4].wall[0];
	}
	else if (n == 20) //Y
	{
		ObrotSciany(4);
		ObrotSciany(5);
		ObrotSciany(5);
		ObrotSciany(5);

		kopia[0] = kostka[1];
		kopia[1] = kostka[2];
		kopia[2] = kostka[3];
		kopia[3] = kostka[0];

	}
	else if (n == 30) //Z
	{
		ObrotSciany(1);
		ObrotSciany(3);
		ObrotSciany(3);
		ObrotSciany(3);

		kopia[4] = kostka[0];
		kopia[0] = kostka[5];
		kopia[5] = kostka[2];
		kopia[2] = kostka[4];
		ObrotSciany(0);
		ObrotSciany(2);
		ObrotSciany(4);
		ObrotSciany(5);
	}

	Kopiuj(kopia, kostka);
	if (wypisz) Wypisz(kostka);
}

void ObrotZnak(char c, int wypisz = 0)
{
	licznik++;
	//l f r b u d
	moves.append(string(1,c));
	if (wypisz) printf("%c %d\n", c,c);
	if (c == 'L' || c == 0) Obrot(0, wypisz);
	else if (c == 'F' || c == 1) Obrot(1, wypisz);
	else if (c == 'R' || c == 2) Obrot(2, wypisz);
	else if (c == 'B' || c == 3) Obrot(3, wypisz);
	else if (c == 'U' || c == 4) Obrot(4, wypisz);
	else if (c == 'D' || c == 5) Obrot(5, wypisz);
	else if (c == 'l' || c == 'L\'' || c == 60)
	{
		Obrot(0, 0);
		Obrot(0, 0);
		Obrot(0, wypisz);
	}
	else if (c == 'f' || c == 'F\'' || c == 61)
	{
		Obrot(1, 0);
		Obrot(1, 0);
		Obrot(1, wypisz);
	}
	else if (c == 'r' || c == 'R\'' || c == 62)
	{
		Obrot(2, 0);
		Obrot(2, 0);
		Obrot(2, wypisz);
	}
	else if (c == 'b' || c == 'B\'' || c == 63)
	{
		Obrot(3, 0);
		Obrot(3, 0);
		Obrot(3, wypisz);
	}
	else if (c == 'u' || c == 'U\'' || c == 64)
	{
		Obrot(4, 0);
		Obrot(4, 0);
		Obrot(4, wypisz);
	}
	else if (c == 'd' || c == 'D\'' || c == 65)
	{
		Obrot(5, 0);
		Obrot(5, 0);
		Obrot(5, wypisz);
	}
	else if (c == 'X') Obrot(10, wypisz);
	else if (c == 'Y') Obrot(20, wypisz);
	else if (c == 'y')
	{
		Obrot(20, 0);
		Obrot(20, 0);
		Obrot(20, wypisz);
	}
	else if (c == 'Z') Obrot(30, wypisz);
}

//bialy krzyz
void Step1()
{
	int up = kostka[4].wall[4];
	while (1)
	{
		
		if (kostka[5].wall[1] == up && kostka[5].wall[3] == up && kostka[5].wall[5] == up && kostka[5].wall[7] == up) break;
		if (kostka[4].wall[7] == up)
		{
			while (1)
			{
				if (kostka[5].wall[1] != up) break;
				ObrotZnak('D', 1);
			}
			ObrotZnak('F', 1);
			ObrotZnak('F', 1);
		}
		if (kostka[4].wall[5] == up)
		{
			while (1)
			{
				if (kostka[5].wall[5] != up) break;
				ObrotZnak('D', 1);
			}
			ObrotZnak('R', 1);
			ObrotZnak('R', 1);
		}
		if (kostka[4].wall[3] == up)
		{
			while (1)
			{
				if (kostka[5].wall[3] != up) break;
				ObrotZnak('D', 1);
			}
			ObrotZnak('L', 1);
			ObrotZnak('L', 1);
		}
		if (kostka[4].wall[1] == up)
		{
			while (1)
			{
				if (kostka[5].wall[7] != up) break;
				ObrotZnak('D', 1);
			}
			ObrotZnak('B', 1);
			ObrotZnak('B', 1);
		}
		if (kostka[1].wall[1] == up || kostka[1].wall[7] == up)
		{
			while (1)
			{
				if (kostka[5].wall[1] != up) break;
				ObrotZnak('D', 1);
			}
			ObrotZnak('F', 1);
		}
		if (kostka[1].wall[3] == up)
		{
			while (1)
			{
				if (kostka[5].wall[3] != up) break;
				ObrotZnak('D', 1);
			}
			ObrotZnak('L', 1);
		}
		if (kostka[1].wall[5] == up)
		{
			while (1)
			{
				if (kostka[5].wall[5] != up) break;
				ObrotZnak('D', 1);
			}
			ObrotZnak('r', 1);
		}
		if (kostka[3].wall[1] == up || kostka[3].wall[7] == up)
		{
			while (1)
			{
				if (kostka[5].wall[7] != up) break;
				ObrotZnak('D', 1);
			}
			ObrotZnak('B', 1);
		}
		if (kostka[3].wall[3] == up)
		{
			while (1)
			{
				if (kostka[5].wall[3] != up) break;
				ObrotZnak('D', 1);
			}
			ObrotZnak('R', 1);
		}
		if (kostka[3].wall[5] == up)
		{
			while (1)
			{
				if (kostka[5].wall[5] != up) break;
				ObrotZnak('D', 1);
			}
			ObrotZnak('l', 1);
		}
		if (kostka[0].wall[1] == up || kostka[0].wall[7] == up)
		{
			while (1)
			{
				if (kostka[5].wall[3] != up) break;
				ObrotZnak('D', 1);
			}
			ObrotZnak('L', 1);
		}
		if (kostka[0].wall[3] == up)
		{
			while (1)
			{
				if (kostka[5].wall[7] != up) break;
				ObrotZnak('D', 1);
			}
			ObrotZnak('B', 1);
		}
		if (kostka[0].wall[5] == up)
		{
			while (1)
			{
				if (kostka[5].wall[1] != up) break;
				ObrotZnak('D', 1);
			}
			ObrotZnak('f', 1);
		}
		if (kostka[2].wall[1] == up || kostka[2].wall[7] == up)
		{
			while (1)
			{
				if (kostka[5].wall[5] != up) break;
				ObrotZnak('D', 1);
			}
			ObrotZnak('R', 1);
		}
		if (kostka[2].wall[3] == up)
		{
			while (1)
			{
				if (kostka[5].wall[1] != up) break;
				ObrotZnak('D', 1);
			}
			ObrotZnak('F', 1);
		}
		if (kostka[2].wall[5] == up)
		{
			while (1)
			{
				if (kostka[5].wall[7] != up) break;
				ObrotZnak('D', 1);
			}
			ObrotZnak('b', 1);
		}

		
	}
	while (1)
	{
		if (kostka[0].wall[7] == kostka[0].wall[4] && kostka[5].wall[3] == up)
		{
			ObrotZnak('L', 1);
			ObrotZnak('L', 1);
		}
		if (kostka[1].wall[7] == kostka[1].wall[4] && kostka[5].wall[1] == up)
		{
			ObrotZnak('F', 1);
			ObrotZnak('F', 1);
		}
		if (kostka[2].wall[7] == kostka[2].wall[4] && kostka[5].wall[5] == up)
		{
			ObrotZnak('R', 1);
			ObrotZnak('R', 1);
		}
		if (kostka[3].wall[7] == kostka[3].wall[4] && kostka[5].wall[7] == up)
		{
			ObrotZnak('B', 1);
			ObrotZnak('B', 1);
		}

		if (kostka[4].wall[1] == up && kostka[4].wall[3] == up && kostka[4].wall[5] == up && kostka[4].wall[7] == up) break;
		else ObrotZnak('D', 1);
	}



} 
//biale narozniki
void Step2()
{
	int up = kostka[4].wall[4];
	int f = 0;
	while (true)
	{
		f = 0;
		if (kostka[4].wall[0] == up && kostka[4].wall[2] == up && kostka[4].wall[6] == up && kostka[4].wall[8] == up) break;
		while (true)
		{
			if (kostka[4].wall[8] == up && kostka[1].wall[2] == kostka[1].wall[4] && kostka[2].wall[0] == kostka[2].wall[4]) break;
			if (kostka[1].wall[8] == kostka[1].wall[4] && kostka[2].wall[6] == up && kostka[5].wall[2] == kostka[2].wall[4])
			{
				ObrotZnak('r', 1);
				ObrotZnak('d', 1);
				ObrotZnak('R', 1);
			}
			if (kostka[2].wall[6] == kostka[2].wall[4] && kostka[1].wall[8] == up && kostka[5].wall[2] == kostka[1].wall[4])
			{
				ObrotZnak('F', 1);
				ObrotZnak('D', 1);
				ObrotZnak('f', 1);
			}
			if (kostka[4].wall[8] == up || kostka[1].wall[2] == up || kostka[2].wall[0] == up)
			{
				if (kostka[1].wall[2] != kostka[1].wall[4] || kostka[2].wall[0] != kostka[2].wall[4])
				{
					ObrotZnak('r', 1);
					ObrotZnak('d', 1);
					ObrotZnak('R', 1);
				}
			}
			if (kostka[2].wall[6] == kostka[1].wall[4] && kostka[1].wall[8] == kostka[2].wall[4] && kostka[5].wall[2] == up)
			{
				ObrotZnak('r', 1);
				ObrotZnak('D', 1);
				ObrotZnak('D', 1);
				ObrotZnak('R', 1);
				ObrotZnak('D', 1);
				ObrotZnak('r', 1);
				ObrotZnak('d', 1);
				ObrotZnak('R', 1);
			}
			ObrotZnak('D', 1);
			if (++f >= 4) break;
		}
		


		ObrotZnak('Y', 1);
		//break;
	}

}
//druga warstwa
void Step3()
{
	while (1)
	{
		if (kostka[0].wall[3] == kostka[0].wall[5] &&
			kostka[1].wall[3] == kostka[1].wall[5] &&
			kostka[2].wall[3] == kostka[2].wall[5] &&
			kostka[3].wall[3] == kostka[3].wall[5] && 
			kostka[0].wall[3] == kostka[0].wall[4])
		{
			return;
		}
		for (int i = 0; i < 4; i++)
		{
			if (kostka[0].wall[3] == kostka[0].wall[5] &&
				kostka[1].wall[3] == kostka[1].wall[5] &&
				kostka[2].wall[3] == kostka[2].wall[5] &&
				kostka[3].wall[3] == kostka[3].wall[5] &&
				kostka[0].wall[3] == kostka[0].wall[4])
			{
				return;
			}
			if (kostka[1].wall[3] == kostka[1].wall[4] && kostka[1].wall[5] == kostka[1].wall[4] &&
				kostka[0].wall[5] == kostka[0].wall[4] && kostka[2].wall[3] == kostka[2].wall[4]) break;
			if (kostka[1].wall[4] == kostka[1].wall[7])
			{
				if (kostka[5].wall[1] == kostka[0].wall[4]) // left
				{
					ObrotZnak('D', 1);
					ObrotZnak('L', 1);
					ObrotZnak('d', 1);
					ObrotZnak('l', 1);
					ObrotZnak('d', 1);
					ObrotZnak('f', 1);
					ObrotZnak('D', 1);
					ObrotZnak('F', 1);
				}
				if (kostka[5].wall[1] == kostka[2].wall[4]) // right
				{
					ObrotZnak('d', 1);
					ObrotZnak('r', 1);
					ObrotZnak('D', 1);
					ObrotZnak('R', 1);
					ObrotZnak('D', 1);
					ObrotZnak('F', 1);
					ObrotZnak('d', 1);
					ObrotZnak('f', 1);
				}
			}
			if (kostka[1].wall[3] == kostka[0].wall[4] && kostka[0].wall[5] == kostka[1].wall[4]) //left switch
			{
				ObrotZnak('D', 1);
				ObrotZnak('L', 1);
				ObrotZnak('d', 1);
				ObrotZnak('l', 1);
				ObrotZnak('d', 1);
				ObrotZnak('f', 1);
				ObrotZnak('D', 1);
				ObrotZnak('F', 1);
				ObrotZnak('d', 1);
				ObrotZnak('L', 1);
				ObrotZnak('d', 1);
				ObrotZnak('l', 1);
				ObrotZnak('d', 1);
				ObrotZnak('f', 1);
				ObrotZnak('D', 1);
				ObrotZnak('F', 1);
			}
			if (kostka[1].wall[5] == kostka[2].wall[4] && kostka[2].wall[5] == kostka[1].wall[4]) //right switch
			{
				ObrotZnak('d', 1);
				ObrotZnak('r', 1);
				ObrotZnak('D', 1);
				ObrotZnak('R', 1);
				ObrotZnak('D', 1);
				ObrotZnak('F', 1);
				ObrotZnak('d', 1);
				ObrotZnak('f', 1);

				ObrotZnak('D', 1);
				ObrotZnak('r', 1);
				ObrotZnak('D', 1);
				ObrotZnak('R', 1);
				ObrotZnak('D', 1);
				ObrotZnak('F', 1);
				ObrotZnak('d', 1);
				ObrotZnak('f', 1);
			}

			if (kostka[1].wall[3] == kostka[1].wall[4] && kostka[0].wall[5] == kostka[2].wall[4] ||
				kostka[1].wall[3] == kostka[3].wall[4] && kostka[0].wall[5] == kostka[2].wall[4]) //left right
			{
				ObrotZnak('D', 1);
				ObrotZnak('L', 1);
				ObrotZnak('d', 1);
				ObrotZnak('l', 1);
				ObrotZnak('d', 1);
				ObrotZnak('f', 1);
				ObrotZnak('D', 1);
				ObrotZnak('F', 1);
			}
			if (kostka[1].wall[5] == kostka[1].wall[4] && kostka[2].wall[3] == kostka[0].wall[4] ||
				kostka[1].wall[5] == kostka[3].wall[4] && kostka[2].wall[3] == kostka[1].wall[4]) //right
			{
				ObrotZnak('d', 1);
				ObrotZnak('r', 1);
				ObrotZnak('D', 1);
				ObrotZnak('R', 1);
				ObrotZnak('D', 1);
				ObrotZnak('F', 1);
				ObrotZnak('d', 1);
				ObrotZnak('f', 1);
			}
			ObrotZnak('D', 1);
		}
		ObrotZnak('Y', 1);
	}
}
//zolty krzyz
void Step4()
{
	ObrotZnak('X', 1);
	ObrotZnak('X', 1);
	while (1)
	{
		int up = kostka[4].wall[4];
		if (kostka[4].wall[1] == up && kostka[4].wall[7] == up && kostka[4].wall[3] == up && kostka[4].wall[5] == up) break;
		if (kostka[4].wall[1] == up && kostka[4].wall[7] == up)
		{
			ObrotZnak('Y', 1);

		}
		if (kostka[4].wall[3] == up && kostka[4].wall[5] == up)
		{
			ObrotZnak('F', 1);
			ObrotZnak('R', 1);
			ObrotZnak('U', 1);
			ObrotZnak('r', 1);
			ObrotZnak('u', 1);
			ObrotZnak('f', 1);
			break;
		}
		//if (kostka[4].wall[1] == up && kostka[4].wall[7] == up && kostka[4].wall[3] == up && kostka[4].wall[5] == up) break;
		if (kostka[4].wall[1] != up && kostka[4].wall[7] != up && kostka[4].wall[3] != up && kostka[4].wall[5] != up)
		{
			ObrotZnak('F', 1);
			ObrotZnak('R', 1);
			ObrotZnak('U', 1);
			ObrotZnak('r', 1);
			ObrotZnak('u', 1);
			ObrotZnak('f', 1);
		}
		if (kostka[4].wall[1] == up && kostka[4].wall[3] == up)
		{
			ObrotZnak('F', 1);
			ObrotZnak('U', 1);
			ObrotZnak('R', 1);
			ObrotZnak('u', 1);
			ObrotZnak('r', 1);
			ObrotZnak('f', 1);
			break;
		}
		if (kostka[4].wall[1] == up && kostka[4].wall[5] == up)
		{
			ObrotZnak('y',1);
		}
		else
		{
			ObrotZnak('Y', 1);
		}
		
	}


}
//zolta warstwa
void Step5()
{
	int up = kostka[4].wall[4];
	int count = 0;
	int flaga = 0;
	while (1)
	{
		flaga = 0;
		count = 0;
		if (kostka[4].wall[0] == up) count++;
		if (kostka[4].wall[8] == up) count++;
		if (kostka[4].wall[6] == up) count++;
		if (kostka[4].wall[2] == up) count++;
		if (count == 4) break;
		//if (kostka[4].wall[0] == up && kostka[4].wall[2] == up && kostka[4].wall[6] == up && kostka[4].wall[8] == up) break;
		if (count == 0)
		{
			if (kostka[0].wall[2] == up)
			{
				ObrotZnak('R', 1);
				ObrotZnak('U', 1);
				ObrotZnak('r', 1);
				ObrotZnak('U', 1);
				ObrotZnak('R', 1);
				ObrotZnak('U', 1);
				ObrotZnak('U', 1);
				ObrotZnak('r', 1);
				flaga = 1;
			}
		}
		else if (count == 1)
		{
			if (kostka[4].wall[6] == up)
			{
				ObrotZnak('R', 1);
				ObrotZnak('U', 1);
				ObrotZnak('r', 1);
				ObrotZnak('U', 1);
				ObrotZnak('R', 1);
				ObrotZnak('U', 1);
				ObrotZnak('U', 1);
				ObrotZnak('r', 1);
				flaga = 1;
			}
			else if (kostka[4].wall[8] == up)
			{
				ObrotZnak('Y', 1);
				ObrotZnak('R', 1);
				ObrotZnak('U', 1);
				ObrotZnak('r', 1);
				ObrotZnak('U', 1);
				ObrotZnak('R', 1);
				ObrotZnak('U', 1);
				ObrotZnak('U', 1);
				ObrotZnak('r', 1);
				flaga = 1;

			}
			else if (kostka[4].wall[0] == up)
			{
				ObrotZnak('y', 1);
				ObrotZnak('R', 1);
				ObrotZnak('U', 1);
				ObrotZnak('r', 1);
				ObrotZnak('U', 1);
				ObrotZnak('R', 1);
				ObrotZnak('U', 1);
				ObrotZnak('U', 1);
				ObrotZnak('r', 1);
				flaga = 1;

			}
			else if (kostka[4].wall[2] == up)
			{
				ObrotZnak('Y', 1);
				ObrotZnak('Y', 1);
				ObrotZnak('R', 1);
				ObrotZnak('U', 1);
				ObrotZnak('r', 1);
				ObrotZnak('U', 1);
				ObrotZnak('R', 1);
				ObrotZnak('U', 1);
				ObrotZnak('U', 1);
				ObrotZnak('r', 1);
				flaga = 1;

			}
			if (kostka[4].wall[0] == up && kostka[4].wall[2] == up && kostka[4].wall[6] == up && kostka[4].wall[8] == up) break;
		}
		else if (count == 2 || count == 3)
		{
			printf("aaaaa count: %d\n", count);
			if (kostka[1].wall[0] == up)
			{
				ObrotZnak('R', 1);
				ObrotZnak('U', 1);
				ObrotZnak('r', 1);
				ObrotZnak('U', 1);
				ObrotZnak('R', 1);
				ObrotZnak('U', 1);
				ObrotZnak('U', 1);
				ObrotZnak('r', 1);
				flaga = 1;

			}
		}
		
		if (flaga != 1)
			ObrotZnak('Y', 1);
		
	}

}
//poprawne zolte narozniki
void Step6()
{
	while (1)
	{
		if (kostka[0].wall[4] == kostka[0].wall[0] && kostka[0].wall[4] == kostka[0].wall[2]
			&& kostka[1].wall[4] == kostka[1].wall[0] && kostka[1].wall[4] == kostka[1].wall[2]
			&& kostka[2].wall[4] == kostka[2].wall[0] && kostka[2].wall[4] == kostka[2].wall[2]
			&& kostka[3].wall[4] == kostka[3].wall[0] && kostka[3].wall[4] == kostka[3].wall[2])
		{
			break;
		}
		if (kostka[1].wall[2] == kostka[1].wall[0])
		{
			ObrotZnak('R', 1);
			ObrotZnak('b', 1);
			ObrotZnak('R', 1);
			ObrotZnak('F', 1);
			ObrotZnak('F', 1);
			ObrotZnak('r', 1);
			ObrotZnak('B', 1);
			ObrotZnak('R', 1);
			ObrotZnak('F', 1);
			ObrotZnak('F', 1);
			ObrotZnak('R', 1);
			ObrotZnak('R', 1);
		}
		else if (kostka[0].wall[2] == kostka[0].wall[0])
		{
			ObrotZnak('y', 1);
			ObrotZnak('R', 1);
			ObrotZnak('b', 1);
			ObrotZnak('R', 1);
			ObrotZnak('F', 1);
			ObrotZnak('F', 1);
			ObrotZnak('r', 1);
			ObrotZnak('B', 1);
			ObrotZnak('R', 1);
			ObrotZnak('F', 1);
			ObrotZnak('F', 1);
			ObrotZnak('R', 1);
			ObrotZnak('R', 1);
		}
		else if (kostka[1].wall[2] == kostka[1].wall[0])
		{
			ObrotZnak('Y', 1);
			ObrotZnak('R', 1);
			ObrotZnak('b', 1);
			ObrotZnak('R', 1);
			ObrotZnak('F', 1);
			ObrotZnak('F', 1);
			ObrotZnak('r', 1);
			ObrotZnak('B', 1);
			ObrotZnak('R', 1);
			ObrotZnak('F', 1);
			ObrotZnak('F', 1);
			ObrotZnak('R', 1);
			ObrotZnak('R', 1);
		}
		else if (kostka[3].wall[2] == kostka[3].wall[0])
		{
			ObrotZnak('Y', 1);
			ObrotZnak('Y', 1);
			ObrotZnak('R', 1);
			ObrotZnak('b', 1);
			ObrotZnak('R', 1);
			ObrotZnak('F', 1);
			ObrotZnak('F', 1);
			ObrotZnak('r', 1);
			ObrotZnak('B', 1);
			ObrotZnak('R', 1);
			ObrotZnak('F', 1);
			ObrotZnak('F', 1);
			ObrotZnak('R', 1);
			ObrotZnak('R', 1);
		}
		else
		{
			ObrotZnak('R', 1);
			ObrotZnak('b', 1);
			ObrotZnak('R', 1);
			ObrotZnak('F', 1);
			ObrotZnak('F', 1);
			ObrotZnak('r', 1);
			ObrotZnak('B', 1);
			ObrotZnak('R', 1);
			ObrotZnak('F', 1);
			ObrotZnak('F', 1);
			ObrotZnak('R', 1);
			ObrotZnak('R', 1);
		}
		
		if (kostka[0].wall[2] == kostka[0].wall[0]
			&& kostka[1].wall[2] == kostka[1].wall[0]
			&& kostka[2].wall[2] == kostka[2].wall[0]
			&& kostka[3].wall[2] == kostka[3].wall[0])
		{
			break;
		}
		Obrot('U', 1);
	}

}
//srodki zoltej sciany
void Step7()
{
	while (true)
	{
		if (kostka[0].wall[0] == kostka[0].wall[1] && kostka[0].wall[0] == kostka[0].wall[2] &&
			kostka[1].wall[0] == kostka[1].wall[1] && kostka[1].wall[0] == kostka[1].wall[2] &&
			kostka[2].wall[0] == kostka[2].wall[1] && kostka[2].wall[0] == kostka[2].wall[2] &&
			kostka[3].wall[0] == kostka[3].wall[1] && kostka[3].wall[0] == kostka[3].wall[2])
		{
			if (kostka[1].wall[4] == kostka[1].wall[2])
				return;
			else if (kostka[1].wall[4] == kostka[2].wall[2])
				ObrotZnak('U',1);
			else if (kostka[1].wall[4] == kostka[3].wall[2])
			{
				ObrotZnak('U',1);
				ObrotZnak('U',1);
			}
				
			else if (kostka[1].wall[4] == kostka[0].wall[2])
				ObrotZnak('u',1);

			return;
		}
		else
		{
			if (kostka[3].wall[4] == kostka[3].wall[2] && kostka[3].wall[4] == kostka[3].wall[1])
			{
				ObrotZnak('R', 1);
				ObrotZnak('u', 1);
				ObrotZnak('R', 1);
				ObrotZnak('U', 1);
				ObrotZnak('R', 1);
				ObrotZnak('U', 1);
				ObrotZnak('R', 1);
				ObrotZnak('u', 1);
				ObrotZnak('r', 1);
				ObrotZnak('u', 1);
				ObrotZnak('R', 1);
				ObrotZnak('R', 1);
			}
			else if (kostka[3].wall[4] == kostka[1].wall[2] && kostka[3].wall[4] == kostka[1].wall[1])
			{
				ObrotZnak('U', 1);
				ObrotZnak('U', 1);
				ObrotZnak('R', 1);
				ObrotZnak('u', 1);
				ObrotZnak('R', 1);
				ObrotZnak('U', 1);
				ObrotZnak('R', 1);
				ObrotZnak('U', 1);
				ObrotZnak('R', 1);
				ObrotZnak('u', 1);
				ObrotZnak('r', 1);
				ObrotZnak('u', 1);
				ObrotZnak('R', 1);
				ObrotZnak('R', 1);
			}
			else if (kostka[3].wall[4] == kostka[0].wall[2] && kostka[3].wall[4] == kostka[0].wall[1])
			{
				ObrotZnak('U', 1);
				ObrotZnak('R', 1);
				ObrotZnak('u', 1);
				ObrotZnak('R', 1);
				ObrotZnak('U', 1);
				ObrotZnak('R', 1);
				ObrotZnak('U', 1);
				ObrotZnak('R', 1);
				ObrotZnak('u', 1);
				ObrotZnak('r', 1);
				ObrotZnak('u', 1);
				ObrotZnak('R', 1);
				ObrotZnak('R', 1);
			}
			else if (kostka[3].wall[4] == kostka[2].wall[2] && kostka[3].wall[4] == kostka[2].wall[1])
			{
				ObrotZnak('u', 1);
				ObrotZnak('R', 1);
				ObrotZnak('u', 1);
				ObrotZnak('R', 1);
				ObrotZnak('U', 1);
				ObrotZnak('R', 1);
				ObrotZnak('U', 1);
				ObrotZnak('R', 1);
				ObrotZnak('u', 1);
				ObrotZnak('r', 1);
				ObrotZnak('u', 1);
				ObrotZnak('R', 1);
				ObrotZnak('R', 1);
			}
			else if (kostka[0].wall[0] != kostka[0].wall[1] && 
				kostka[1].wall[0] != kostka[1].wall[1] && 
				kostka[2].wall[0] != kostka[2].wall[1] && 
				kostka[3].wall[0] != kostka[3].wall[1] )
			{
				ObrotZnak('R', 1);
				ObrotZnak('u', 1);
				ObrotZnak('R', 1);
				ObrotZnak('U', 1);
				ObrotZnak('R', 1);
				ObrotZnak('U', 1);
				ObrotZnak('R', 1);
				ObrotZnak('u', 1);
				ObrotZnak('r', 1);
				ObrotZnak('u', 1);
				ObrotZnak('R', 1);
				ObrotZnak('R', 1);
			}
		}
		ObrotZnak('Y', 1);
	}

}
int _tmain(int argc, _TCHAR* argv[])
{
	start();
	Random(30);
	/*ObrotZnak(1, 0);
	ObrotZnak(1, 0);
	ObrotZnak(2, 0);
	ObrotZnak(0, 0);
	ObrotZnak(0, 0);
	ObrotZnak(1, 0);
	ObrotZnak(3, 0);
	ObrotZnak(2, 0);
	ObrotZnak(2, 0);
	ObrotZnak(5, 0);
	ObrotZnak(5, 0);
	ObrotZnak(4, 0);
	ObrotZnak(4, 0);
	ObrotZnak(1, 0);*/

	licznik = 0;
	Wypisz(kostka);
	Step1();
	Step2();
	Step3();
	Step4();
	Step5();
	Step6();
	Step7();
	while(1)
	{

		printf("\n*****************************************************\n");
		char k = _getch();
		if (k == 'q') break;
		ObrotZnak(k, 1);
	}

	printf("licznik %d\n%s\n", licznik,moves.c_str());
	return 0;
}

