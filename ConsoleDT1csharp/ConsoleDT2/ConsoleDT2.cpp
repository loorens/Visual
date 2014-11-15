// ConsoleDT2.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <stdio.h>
#include <stdlib.h>
#include <time.h>

int _tmain(int argc, _TCHAR* argv[])
{
	srand(time(NULL));

	int n;
	int nk=0;
	double x,y;
	float s;

	for (n = 10; n < 1000000; n*=10)
	{
		nk=0;
		for (int i=1; i <= n; i++)
		{
			 x = ((double)rand() / (RAND_MAX))*2 -1;
			 y = ((double)rand() / (RAND_MAX))*2 -1;
			 if(x*x + y*y <= 1)
			 {
				 nk++;
			 }
		}
		printf("Liczba losowan: %i\nLiczba pkt. w kole wynosi: %d\n",n,nk);
		s = 4. * nk / n;
		printf("Pi: %f\n",s);
		
	}
	getchar();
	return 0;
}

