// ConsoleDT1.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <stdlib.h>
#include <time.h>
#include <math.h>
#include <random>
#include <stdio.h>
struct Item
{
	unsigned short Weight;
	unsigned short Value;
};

void FullSearch(Item * items, unsigned int &globalMaximumValue, unsigned int &globalMaximum);
void MonteCarloSearch( Item* items, unsigned int &globalMaximumValue,
									unsigned int &globalMaximum,
									unsigned int &iteriationMaximum,
									unsigned int numberOfIterations);
void RandomWalk( Item* items, unsigned int &globalMaximumValue,
									unsigned int &globalMaximum,
									unsigned int &iteriationMaximum,
									unsigned int numberOfSteps);
void ClimbingFromPointZero( Item* items, unsigned int &globalMaximumValue,
									unsigned int &globalMaximum,
									unsigned int &iteriationMaximum,
									unsigned int numberOfSteps);
void ClimbingFromRandomPoint(Item* items, unsigned int &globalMaximumValue,
	unsigned int &globalMaximum,
	unsigned int &iteriationMaximum,
	unsigned int numberOfSteps);

std::random_device rd;
std::uniform_int_distribution<int> distribution(INT_MIN, INT_MAX);

#define MAX_KNAPSACK_WEIGHT 300u
#define NUMBER_OF_CINBINATIONS (2u * INT_MAX)
#define ELEMENTS_NUMBER (sizeof(int) * 8)

#define CHECK_BIT(var,pos) ((var) & (1<<(pos)))
#define CHANGE_BIT(var,pos) ((var) ^ (1<<(pos)))

int _tmain(int argc, _TCHAR* argv[])
{
	Item * items;
	items = (Item *)malloc(sizeof(Item) * ELEMENTS_NUMBER);
	unsigned int GlobalMaximum = 0;
	unsigned int GlobalMaximumValue = 0;
	unsigned int IterationMaximum = 0;

	srand(time(NULL));
	time_t timeStart = time(NULL);
	time_t timeOfSearch = time(NULL) - timeStart;


#pragma region zmienne
	items[0].Weight = 10;
	items[0].Value = 22;
	items[1].Weight = 7;
	items[1].Value = 30;
	items[2].Weight = 1;
	items[2].Value = 27;
	items[3].Weight = 4;
	items[3].Value = 27;
	items[4].Weight = 9;
	items[4].Value = 29;
	items[5].Weight = 6;
	items[5].Value = 30;
	items[6].Weight = 5;
	items[6].Value = 30;
	items[7].Weight = 3;
	items[7].Value = 30;
	items[8].Weight = 11;
	items[8].Value = 10;
	items[9].Weight = 14;
	items[9].Value = 21;
	items[10].Weight = 13;
	items[10].Value = 8;
	items[11].Weight = 15;
	items[11].Value = 29;
	items[12].Weight = 14;
	items[12].Value = 2;
	items[13].Weight = 14;
	items[13].Value = 23;
	items[14].Weight = 13;
	items[14].Value = 28;
	items[15].Weight = 12;
	items[15].Value = 2;
	items[16].Weight = 19;
	items[16].Value = 23;
	items[17].Weight = 12;
	items[17].Value = 23;
	items[18].Weight = 17;
	items[18].Value = 15;
	items[19].Weight = 18;
	items[19].Value = 11;
	items[20].Weight = 15;
	items[20].Value = 24;
	items[21].Weight = 13;
	items[21].Value = 5;
	items[22].Weight = 15;
	items[22].Value = 15;
	items[23].Weight = 17;
	items[23].Value = 17;
	items[24].Weight = 11;
	items[24].Value = 11;
	items[25].Weight = 20;
	items[25].Value = 1;
	items[26].Weight = 2;
	items[26].Value = 22;
	items[27].Weight = 8;
	items[27].Value = 6;
	items[28].Weight = 10;
	items[28].Value = 25;
	items[29].Weight = 7;
	items[29].Value = 22;
	items[30].Weight = 9;
	items[30].Value = 14;
	items[31].Weight = 1;
	items[31].Value = 12;
#pragma endregion
	/*
	timeStart = time(NULL);
	FullSearch(items, GlobalMaximumValue, GlobalMaximum);
	timeOfSearch = time(NULL) - timeStart;
	printf("Maximum = %u\nMaks value = %u\nSearch time = %i[s]\n",GlobalMaximum, GlobalMaximumValue, timeOfSearch );
	/**/
	/*
	GlobalMaximum = GlobalMaximumValue = IterationMaximum = 0;
	timeStart = time(NULL);
	MonteCarloSearch(items, GlobalMaximumValue, GlobalMaximum, IterationMaximum, 10);
	timeOfSearch = time(NULL) - timeStart;
	printf("Monte Carlo(10) Search:\nMaximum = %u\nMax value = %u\nIteration = %u\nSearch time = %i[s]\n", GlobalMaximum, GlobalMaximumValue, IterationMaximum, timeOfSearch);

	GlobalMaximum = GlobalMaximumValue = IterationMaximum = 0;
	timeStart = time(NULL);
	MonteCarloSearch(items, GlobalMaximumValue, GlobalMaximum, IterationMaximum, 1000);
	timeOfSearch = time(NULL) - timeStart;
	printf("Monte Carlo(1 000) Search:\nMaximum = %u\nMax value = %u\nIteration = %u\nSearch time = %i[s]\n", GlobalMaximum, GlobalMaximumValue, IterationMaximum, timeOfSearch);

	GlobalMaximum = GlobalMaximumValue = IterationMaximum = 0;
	timeStart = time(NULL);
	MonteCarloSearch(items, GlobalMaximumValue, GlobalMaximum, IterationMaximum, 1000000);
	timeOfSearch = time(NULL) - timeStart;
	printf("Monte Carlo(1 000 000) Search:\nMaximum = %u\nMax value = %u\nIteration = %u\nSearch time = %i[s]\n\n", GlobalMaximum, GlobalMaximumValue, IterationMaximum, timeOfSearch);
	*/
	/*
	for (int i = 0; i < 20; i++)
	{
		GlobalMaximum = GlobalMaximumValue = IterationMaximum = 0;
		timeStart = time(NULL);
		RandomWalk(items, GlobalMaximumValue, GlobalMaximum, IterationMaximum, 100);
		timeOfSearch = time(NULL) - timeStart;
		printf("%i. Random walking Search:\nMaximum = %u\nMax value = %u\nIteration = %u\nSearch time = %i[s]\n\n",i+1, GlobalMaximum, GlobalMaximumValue, IterationMaximum, timeOfSearch);
	}
	*/
	/*
	float srednia =0;
	float wart[20];
	for (int i = 0; i < 20; i++)
	{
		GlobalMaximum = GlobalMaximumValue = IterationMaximum = 0;
		timeStart = time(NULL);
		ClimbingFromPointZero(items, GlobalMaximumValue, GlobalMaximum, IterationMaximum, 100);
		timeOfSearch = time(NULL) - timeStart;
		printf("%i. Climbing from point zero:\nMaximum = %u\nMax value = %u\nR = %u\nIteration = %u\nSearch time = %i[s]\n\n", 
			i+1, GlobalMaximum, GlobalMaximumValue, 589-GlobalMaximumValue, IterationMaximum, timeOfSearch);
		srednia += GlobalMaximumValue;
		wart[i]=GlobalMaximumValue;
	}
	printf("Srednia: %f\n",srednia/20.0);
	double war=0;
	for (int i = 0; i < 20; i++)
	{
		printf("%d\n", (int)wart[i]);
		war += (wart[i]-srednia/20.0)*(wart[i]-srednia/20.0);
	}
	printf("Wariancja: %f\n",war/20.0);
	*/

	float srednia = 0;
	float wart[20];
	for (int i = 0; i < 20; i++)
	{
		GlobalMaximum = GlobalMaximumValue = IterationMaximum = 0;
		timeStart = time(NULL);
		ClimbingFromRandomPoint(items, GlobalMaximumValue, GlobalMaximum, IterationMaximum, (((100 *i) *i)*i)*i + 100);
		timeOfSearch = time(NULL) - timeStart;
		printf("%i. Climbing from point zero:\nMaximum = %u\nMax value = %u\nR = %u\nIteration = %u\nSearch time = %i[s]\n\n",
			i + 1, GlobalMaximum, GlobalMaximumValue, 589 - GlobalMaximumValue, IterationMaximum, timeOfSearch);
		srednia += GlobalMaximumValue;
		wart[i] = GlobalMaximumValue;
	}
	printf("Srednia: %f\n", srednia / 20.0);
	double war = 0;
	for (int i = 0; i < 20; i++)
	{
		printf("%d\n", (int)wart[i]);
		war += (wart[i] - srednia / 20.0)*(wart[i] - srednia / 20.0);
	}
	printf("Wariancja: %f\n", war / 20.0);


	getchar();


	//for(int i=0; i<32; i++) printf("items[%d].Weight = ;\nitems[%d].Value = ;\n",i,i);

	return 0;
}

void FullSearch(Item * items, unsigned int &globalMaximumValue, unsigned int &globalMaximum)
{
	unsigned int weight, value;
	for (unsigned int i = 0; i < NUMBER_OF_CINBINATIONS; i++)
	{
		weight = 0;
		value = 0;
		for (unsigned int j = 0; j < ELEMENTS_NUMBER; j++)
		{
			if(CHECK_BIT(i,j))
			{
				weight += items[j].Weight;
				value += items[j].Value;
			}
		}
		if(weight < MAX_KNAPSACK_WEIGHT && value > globalMaximumValue)
		{
			globalMaximumValue = value;
			globalMaximum = i;
		}
	}
}

void MonteCarloSearch( Item* items, unsigned int &globalMaximumValue,
									unsigned int &globalMaximum,
									unsigned int &iteriationMaximum,
									unsigned int numberOfIterations)
{
	unsigned int weight, value;
	unsigned int pointOfSpaceSearch;
	for (unsigned int i = 0; i < numberOfIterations; i++)
	{
		/*pointOfSpaceSearch = rand();
		if(rand() % 2) 
			pointOfSpaceSearch = ~pointOfSpaceSearch;*/
		pointOfSpaceSearch = distribution(rd);
		weight =0;
		value = 0;
		for (int j = 0; j < ELEMENTS_NUMBER; j++)
		{
			
			if (CHECK_BIT(pointOfSpaceSearch, j))
			{
				weight +=items[j].Weight;
				value += items[j].Value;
			}
		}
		if (weight <= MAX_KNAPSACK_WEIGHT && value > globalMaximumValue)
		{
			globalMaximumValue = value;
			globalMaximum = pointOfSpaceSearch;
			iteriationMaximum = i;
		}


	}

}

void RandomWalk( Item* items, unsigned int &globalMaximumValue,
									unsigned int &globalMaximum,
									unsigned int &iteriationMaximum,
									unsigned int numberOfSteps)
{
	unsigned int weight, value;
	unsigned int startingPoint = distribution(rd);
	int changeBit;
	for (unsigned int i = 0; i < numberOfSteps; i++)
	{
		weight =0; value =0;
		changeBit = distribution(rd) % ELEMENTS_NUMBER;
		startingPoint = CHANGE_BIT(startingPoint, changeBit);
		for (unsigned int j = 0; j < ELEMENTS_NUMBER; j++)
		{
			if (CHECK_BIT(startingPoint, j))
			{
				weight +=items[j].Weight;
				value += items[j].Value;
			}
		}
		if (weight <= MAX_KNAPSACK_WEIGHT && value > globalMaximumValue)
		{
			globalMaximumValue = value;
			globalMaximum = startingPoint;
			iteriationMaximum = i;
		}
	}
}

void ClimbingFromPointZero( Item* items, unsigned int &globalMaximumValue,
									unsigned int &globalMaximum,
									unsigned int &iteriationMaximum,
									unsigned int numberOfSteps)
{
	unsigned int weight, value, newWeight, newValue;
	unsigned int startingPoint = 0, newPoint =0; 
	int changeBit = 0;
	for (unsigned int i = 0; i < numberOfSteps; i++)
	{
		weight =0; value =0; newWeight = 0; newValue = 0;
		changeBit = distribution(rd) % ELEMENTS_NUMBER;
		newPoint = CHANGE_BIT(startingPoint, changeBit);

		for (unsigned int j = 0; j < ELEMENTS_NUMBER; j++)
		{
			if (CHECK_BIT(startingPoint, j))
			{
				weight +=items[j].Weight;
				value += items[j].Value;
			}
			if(CHECK_BIT(newPoint ,j))
			{
				newWeight +=items[j].Weight;
				newValue += items[j].Value;
			}
		}
		if (newWeight <= MAX_KNAPSACK_WEIGHT && newValue > globalMaximumValue)
		{
			globalMaximumValue = newValue;
			globalMaximum = startingPoint = newPoint;
			iteriationMaximum = i;
		}
	}
}

void ClimbingFromRandomPoint( Item* items, unsigned int &globalMaximumValue,
									unsigned int &globalMaximum,
									unsigned int &iteriationMaximum,
									unsigned int numberOfSteps)
{
	unsigned int weight, value, newWeight, newValue;
	unsigned int startingPoint = distribution(rd);
	unsigned int newPoint =0; 
	int changeBit = 0;
	for (unsigned int i = 0; i < numberOfSteps; i++)
	{
		weight =0; value =0; newWeight = 0; newValue = 0;
		changeBit = distribution(rd) % ELEMENTS_NUMBER;
		newPoint = CHANGE_BIT(startingPoint, changeBit);

		for (unsigned int j = 0; j < ELEMENTS_NUMBER; j++)
		{
			if (CHECK_BIT(startingPoint, j))
			{
				weight +=items[j].Weight;
				value += items[j].Value;
			}
			if(CHECK_BIT(newPoint ,j))
			{
				newWeight +=items[j].Weight;
				newValue += items[j].Value;
			}
		}
		if (newWeight <= MAX_KNAPSACK_WEIGHT && newValue > globalMaximumValue)
		{
			globalMaximumValue = newValue;
			globalMaximum = startingPoint = newPoint;
			iteriationMaximum = i;
		}
		else
		{
			if(weight > MAX_KNAPSACK_WEIGHT && newWeight < weight)
			{
				startingPoint = newPoint;
				if(newWeight < MAX_KNAPSACK_WEIGHT)
				{
					globalMaximum = startingPoint;
					globalMaximumValue = newPoint;
					iteriationMaximum = i;
				}
			}
		}
	}
}