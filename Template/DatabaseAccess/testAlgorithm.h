#pragma once

#include <string.h>
#include <iostream>
using namespace std;

#ifdef CPPWIN32DLL_EXPORTS
#define CPPWIN32DLL_API __declspec(dllexport)
#else 
#define CPPWIN32DLL_API __declspec(dllimport) 
#endif

int& CPPWIN32DLL_API getAges(string fname, int cnum);
int& CPPWIN32DLL_API getWait(string fname, int cnum);
int& CPPWIN32DLL_API getEthnic(string fname, int cnum);
int& CPPWIN32DLL_API getIncome(string fname, int cnum);
int& CPPWIN32DLL_API getFairness(string fname, int cnum)