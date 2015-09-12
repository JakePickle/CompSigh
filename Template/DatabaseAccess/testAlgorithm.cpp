#include "pch.h"
#ifdef CPPWIN32DLL_EXPORTS
#define CPPWIN32DLL_API __declspec(dllexport)
#else 
#define CPPWIN32DLL_API __declspec(dllimport) 
#endif

#include <iostream>
#include <vector>

using namespace std;



class Case
{
  public:
	  Case(int ticketNumber, string firstName, string lastName, int ages, int ethnici, int incomez, int fairz, string addz, int waitz, string datez)
	  {
		  ticketnum = ticketNumber;
		  fname = firstName;
		  lname = lastName;
		  age = ages;
		  ethnic = ethnici;
		  income = incomez;
		  fair = fairz;
		  wait = waitz;
		  date = datez;
	  }
    int ticketnum;
    string fname;
    string lname;
    int age;
    int ethnic;
    int income;
    int fair;
    string add;
    int wait;
    string date;

};

vector<Case> allCases;
int numCases=0;


void CPPWIN32DLL_API PushToDatabase(int ticketNumber, string firstName, string lastName, int ages, int ethnici, int incomez, int fairz, string addz, int waitz, string datez)
{
	Case dude(ticketNumber, firstName, lastName, ages, ethnici, incomez, fairz, addz, waitz, datez);

	allCases.push_back(dude);
}

int* getAges()
{
	int case0num = 0;
	int case1num = 0;
	int case2num = 0;
	int case3num = 0;
	int case4num = 0;
	int case5num = 0;
	int case6num = 0;
	int case7num = 0;
	for(int i=0;i<numCases;i++)
	{
		switch(allCases[i].age)
		{
			case 0:
				case0num++;
				break;
			case 1:
				case1num++;
				break;
			case 2:
				case2num++;
				break;
			case 3:
				case3num++;
				break;
			case 4:
				case4num++;
				break;
			case 5:
				case5num++;
				break;
			case 6:
				case6num++;
				break;
			case 7:
				case7num++;
				break;
		}
	}
	int arr[8]= {case0num,case1num,case2num,case3num,case4num,case5num,case6num,case7num};
	int* ptr = arr;
	return (ptr);
}

int* getRaces()
{
	int case0num = 0;
	int case1num = 0;
	int case2num = 0;
	int case3num = 0;
	int case4num = 0;
	int case5num = 0;
	int case6num = 0;
	int case7num = 0;
	for(int i=0;i<numCases;i++)
	{
		switch(allCases[i].ethnic)
		{
			case 0:
				case0num++;
				break;
			case 1:
				case1num++;
				break;
			case 2:
				case2num++;
				break;
			case 3:
				case3num++;
				break;
			case 4:
				case4num++;
				break;
			case 5:
				case5num++;
				break;
			case 6:
				case6num++;
				break;
			case 7:
				case7num++;
				break;
		}
	}
	int arr[8]= {case0num,case1num,case2num,case3num,case4num,case5num,case6num,case7num};
	int* ptr = arr;
	return (ptr);
}

int* getIncomes()
{
	int case0num = 0;
	int case1num = 0;
	int case2num = 0;
	int case3num = 0;
	int case4num = 0;
	int case5num = 0;
	for(int i=0;i<numCases;i++)
	{
		switch(allCases[i].income)
		{
			case 0:
				case0num++;
				break;
			case 1:
				case1num++;
				break;
			case 2:
				case2num++;
				break;
			case 3:
				case3num++;
				break;
			case 4:
				case4num++;
				break;
			case 5:
				case5num++;
				break;
		}
	}
	int arr[6]= {case0num,case1num,case2num,case3num,case4num,case5num};
	int* ptr = arr;
	return (ptr);
}
