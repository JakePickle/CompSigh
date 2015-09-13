#include "pch.h"
#include <iostream>
#include <fstream>
#include <string>
#include <cstdlib>
#include <ctime>

using namespace std;



bool withinDay(int day, int month, int year)
{
  time_t t = time(0);
  tm* now = localtime(&t);
  int curday=now->tm_mday;
  int curmonth=(now->tm_mon)+1;
  int curyear=(now->tm_year)+1900;
  if(curday==day&&curmonth==month&&curyear==year)
    return true;
  return false;
}

bool withinWeek(int day, int month, int year)
{
  time_t t = time(0);
  tm* now = localtime(&t);
  int curday=now->tm_mday;
  int curmonth=(now->tm_mon)+1;
  int curyear=(now->tm_year)+1900;
  if(curyear==year)
  {
    if(curmonth==month)
    {
      if(curday>day)
      {
        if(curday-day<=7)
        {
          return true;
        }
        if(day-curday<=7)
        {
          return true;
        }
      }
    }
  }
  return false;
}

bool withinMonth(int day, int month, int year)
{
  time_t t = time(0);
  tm* now = localtime(&t);
  int curday=now->tm_mday;
  int curmonth=(now->tm_mon)+1;
  int curyear=(now->tm_year)+1900;
  if(curyear==year)
  {
    if(curmonth==month)
    {
      return true;
    }
    if(curmonth==month-1)
    {
      if(day>curday)
      {
        return true;
      }
    }
  }
  return false;
}

bool withinYear(int day, int month, int year)
{
  time_t t = time(0);
  tm* now = localtime(&t);
  int curday=now->tm_mday;
  int curmonth=(now->tm_mon)+1;
  int curyear=(now->tm_year)+1900;
  if(curyear==year)
  {
    return true;
  }
  if(curyear==year+1)
  {
    if(month>curmonth)
    {
      return true;
    }
    if(curday<day)
    {
      return true;
    }
  }
  if(curyear==year-1)
  {
    if(month<curmonth)
    {
      return true;
    }
    if(month==curmonth)
    {
      if(day<curday)
      {
        return true;
      }
    }
  }
  return false;
}

int& getAges(string fname, int cnum)
{
	ifstream fileAges(fname);
	int word=0;
	int day=0;
	int month=0;
	int year=0;
	int case0num=0;
	int case1num=0;
	int case2num=0;
	int case3num=0;
	int case4num=0;
	int case5num=0;
	int case6num=0;
	int case7num=0;
	while(fileAges.good())
	{
		switch(cnum)
		{
			case 4:
				fileAges>>word;
				fileAges.ignore();
				fileAges.ignore();
				fileAges.ignore();
				fileAges.ignore();
				fileAges.ignore();
				fileAges.ignore();
				switch(word)
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
					default:
						cout<<"test"<<endl;
						break;
				}
				break;

			case 3:
				fileAges>>word;
				fileAges.ignore();
				fileAges>>day;
				fileAges.ignore();
				fileAges>>month;
				fileAges.ignore();
				fileAges>>year;
				if(withinYear(day,month,year))
				{
					switch(word)
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
					default:
						cout<<"test"<<endl;
						break;
					}
				}
				break;

			case 2:
				fileAges>>word;
				fileAges.ignore();
				fileAges>>day;
				fileAges.ignore();
				fileAges>>month;
				fileAges.ignore();
				fileAges>>year;
				if(withinMonth(day,month,year))
				{
					switch(word)
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
					default:
						cout<<"test"<<endl;
						break;
					}
				}
				break;

			case 1:
				fileAges>>word;
				fileAges.ignore();
				fileAges>>day;
				fileAges.ignore();
				fileAges>>month;
				fileAges.ignore();
				fileAges>>year;
				if(withinWeek(day,month,year))
				{
					switch(word)
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
					default:
						cout<<"test"<<endl;
						break;
					}
				}
				break;

			case 0:
				fileAges>>word;
				fileAges.ignore();
				fileAges>>day;
				fileAges.ignore();
				fileAges>>month;
				fileAges.ignore();
				fileAges>>year;
				if(withinDay(day,month,year))
				{
					switch(word)
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
					default:
						cout<<"test"<<endl;
						break;
					}
				}
				break;
		}
	}
	fileAges.close();
	int* ret = new int[8]{case0num,case1num,case2num,case3num,case4num,case5num,case6num,case7num};
	return *(ret);
}

int& getWait(string fname, int cnum)
{
	ifstream fileWait(fname);
	int word=0;
	int day=0;
	int month=0;
	int year=0;
	int case0num=0;
	int case1num=0;
	int case2num=0;
	int case3num=0;
	int case4num=0;
	int case5num=0;
	while(fileWait.good())
	{
		switch(cnum)
		{
			case 4:
				fileWait>>word;
				fileWait.ignore();
				fileWait.ignore();
				fileWait.ignore();
				fileWait.ignore();
				fileWait.ignore();
				fileWait.ignore();
				switch(word)
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
					default:
						cout<<"test"<<endl;
						break;
				}
				break;

			case 3:
				fileWait>>word;
				fileWait.ignore();
				fileWait>>day;
				fileWait.ignore();
				fileWait>>month;
				fileWait.ignore();
				fileWait>>year;
				if(withinYear(day,month,year))
				{
					switch(word)
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
					default:
						cout<<"test"<<endl;
						break;
					}
				}
				break;

			case 2:
				fileWait>>word;
				fileWait.ignore();
				fileWait>>day;
				fileWait.ignore();
				fileWait>>month;
				fileWait.ignore();
				fileWait>>year;
				if(withinMonth(day,month,year))
				{
					switch(word)
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
					default:
						cout<<"test"<<endl;
						break;
					}
				}
				break;

			case 1:
				fileWait>>word;
				fileWait.ignore();
				fileWait>>day;
				fileWait.ignore();
				fileWait>>month;
				fileWait.ignore();
				fileWait>>year;
				if(withinWeek(day,month,year))
				{
					switch(word)
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
					default:
						cout<<"test"<<endl;
						break;
					}
				}
				break;

			case 0:
				fileWait>>word;
				fileWait.ignore();
				fileWait>>day;
				fileWait.ignore();
				fileWait>>month;
				fileWait.ignore();
				fileWait>>year;
				if(withinDay(day,month,year))
				{
					switch(word)
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
					default:
						cout<<"test"<<endl;
						break;
					}
				}
				break;
		}
	}
	fileWait.close();
	int* ret = new int[6]{case0num,case1num,case2num,case3num,case4num,case5num};
	return *(ret);
}

int& getEthnic(string fname, int cnum)
{
	ifstream fin(fname);
	int word=0;
	int day=0;
	int month=0;
	int year=0;
	int case0num=0;
	int case1num=0;
	int case2num=0;
	int case3num=0;
	int case4num=0;
	int case5num=0;
	int case6num=0;
	int case7num=0;
	while(fin.good())
	{
		switch(cnum)
		{
			case 4:
				fin>>word;
				fin.ignore();
				fin.ignore();
				fin.ignore();
				fin.ignore();
				fin.ignore();
				fin.ignore();
				switch(word)
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
					default:
						cout<<"test"<<endl;
						break;
				}
				break;

			case 3:
				fin>>word;
				fin.ignore();
				fin>>day;
				fin.ignore();
				fin>>month;
				fin.ignore();
				fin>>year;
				if(withinYear(day,month,year))
				{
					switch(word)
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
					default:
						cout<<"test"<<endl;
						break;
					}
				}
				break;

			case 2:
				fin>>word;
				fin.ignore();
				fin>>day;
				fin.ignore();
				fin>>month;
				fin.ignore();
				fin>>year;
				if(withinMonth(day,month,year))
				{
					switch(word)
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
					default:
						cout<<"test"<<endl;
						break;
					}
				}
				break;

			case 1:
				fin>>word;
				fin.ignore();
				fin>>day;
				fin.ignore();
				fin>>month;
				fin.ignore();
				fin>>year;
				if(withinWeek(day,month,year))
				{
					switch(word)
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
					default:
						cout<<"test"<<endl;
						break;
					}
				}
				break;

			case 0:
				fin>>word;
				fin.ignore();
				fin>>day;
				fin.ignore();
				fin>>month;
				fin.ignore();
				fin>>year;
				if(withinDay(day,month,year))
				{
					switch(word)
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
					default:
						cout<<"test"<<endl;
						break;
					}
				}
				break;
		}
	}
	fin.close();
	int* ret = new int[8]{case0num,case1num,case2num,case3num,case4num,case5num,case6num,case7num};
	return *(ret);
}

int& getIncome(string fname, int cnum)
{
	ifstream fin(fname);
	int word=0;
	int day=0;
	int month=0;
	int year=0;
	int case0num=0;
	int case1num=0;
	int case2num=0;
	int case3num=0;
	int case4num=0;
	int case5num=0;
	while(fin.good())
	{
		switch(cnum)
		{
			case 4:
				fin>>word;
				fin.ignore();
				fin.ignore();
				fin.ignore();
				fin.ignore();
				fin.ignore();
				fin.ignore();
				switch(word)
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
					default:
						cout<<"test"<<endl;
						break;
				}
				break;

			case 3:
				fin>>word;
				fin.ignore();
				fin>>day;
				fin.ignore();
				fin>>month;
				fin.ignore();
				fin>>year;
				if(withinYear(day,month,year))
				{
					switch(word)
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
					default:
						cout<<"test"<<endl;
						break;
					}
				}
				break;

			case 2:
				fin>>word;
				fin.ignore();
				fin>>day;
				fin.ignore();
				fin>>month;
				fin.ignore();
				fin>>year;
				if(withinMonth(day,month,year))
				{
					switch(word)
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
					default:
						cout<<"test"<<endl;
						break;
					}
				}
				break;

			case 1:
				fin>>word;
				fin.ignore();
				fin>>day;
				fin.ignore();
				fin>>month;
				fin.ignore();
				fin>>year;
				if(withinWeek(day,month,year))
				{
					switch(word)
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
					default:
						cout<<"test"<<endl;
						break;
					}
				}
				break;

			case 0:
				fin>>word;
				fin.ignore();
				fin>>day;
				fin.ignore();
				fin>>month;
				fin.ignore();
				fin>>year;
				if(withinDay(day,month,year))
				{
					switch(word)
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
					default:
						cout<<"test"<<endl;
						break;
					}
				}
				break;
		}
	}
	fin.close();
	int* ret = new int[6]{case0num,case1num,case2num,case3num,case4num,case5num};
	return *(ret);
}

int& getFairness(string fname, int cnum)
{
	ifstream fin(fname);
	int word=0;
	int day=0;
	int month=0;
	int year=0;
	int case0num=0;
	int case1num=0;
	int case2num=0;
	int case3num=0;
	int case4num=0;
	int case5num=0;
	while(fin.good())
	{
		switch(cnum)
		{
			case 4:
				fin>>word;
				fin.ignore();
				fin.ignore();
				fin.ignore();
				fin.ignore();
				fin.ignore();
				fin.ignore();
				switch(word)
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
					default:
						cout<<"test"<<endl;
						break;
				}
				break;

			case 3:
				fin>>word;
				fin.ignore();
				fin>>day;
				fin.ignore();
				fin>>month;
				fin.ignore();
				fin>>year;
				if(withinYear(day,month,year))
				{
					switch(word)
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
					default:
						cout<<"test"<<endl;
						break;
					}
				}
				break;

			case 2:
				fin>>word;
				fin.ignore();
				fin>>day;
				fin.ignore();
				fin>>month;
				fin.ignore();
				fin>>year;
				if(withinMonth(day,month,year))
				{
					switch(word)
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
					default:
						cout<<"test"<<endl;
						break;
					}
				}
				break;

			case 1:
				fin>>word;
				fin.ignore();
				fin>>day;
				fin.ignore();
				fin>>month;
				fin.ignore();
				fin>>year;
				if(withinWeek(day,month,year))
				{
					switch(word)
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
					default:
						cout<<"test"<<endl;
						break;
					}
				}
				break;

			case 0:
				fin>>word;
				fin.ignore();
				fin>>day;
				fin.ignore();
				fin>>month;
				fin.ignore();
				fin>>year;
				if(withinDay(day,month,year))
				{
					switch(word)
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
					default:
						cout<<"test"<<endl;
						break;
					}
				}
				break;
		}
	}
	fin.close();
	int* ret = new int[6]{case0num,case1num,case2num,case3num,case4num,case5num};
	return *(ret);
}
