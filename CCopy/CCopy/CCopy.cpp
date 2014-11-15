// CCopy.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <stdlib.h>

int main(int argc, char *argv[])
{
	if (argc < 3)
	{
		printf("blad argumentow, uzyj killingCopy file1 file2 ");
		int i;
		for (i = 0; i < argc; i++)
		{
			printf("arg %d: %s\n", i, argv[i]);
		}
		return 0;
	}

	FILE * file1 = fopen(argv[1], "r");
	FILE * file2 = fopen(argv[2], "r+");
	char buf[512];
	int count;
	while (1)
	{
		count = read(file1, buf, 512);
		write(file2, buf, count);
		if (count != 512) break;
	}

	fclose(file1);
	fclose(file2);
	return 0;
}

