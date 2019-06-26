// dllmain.cpp : 定义 DLL 应用程序的入口点。
#include "stdafx.h"
#include  "Win32.h"
extern "C" __declspec(dllexport) int getTotalPages(int a, int b, int c, int d);
int getTotalPages(int a, int b, int c, int d)
{
	PageHelper pageHelper;
	pageHelper.Initialize(a, b, c, d);
	return pageHelper.GetTotalPages();
}

extern "C" __declspec(dllexport) int getStartPage(int a, int b, int c, int d);
int getStartPage(int a, int b, int c, int d)
{
	PageHelper pageHelper;
	pageHelper.Initialize(a, b, c, d);
	return pageHelper.GetStartPage();
}

extern "C" __declspec(dllexport) int getEndPage(int a, int b, int c, int d);
int getEndPage(int a, int b, int c, int d)
{
	PageHelper pageHelper;
	pageHelper.Initialize(a, b, c, d);
	return pageHelper.GetEndPage();
}

extern "C" __declspec(dllexport) int getStartData(int a, int b, int c, int d);
int getStartData(int a, int b, int c, int d)
{
	PageHelper pageHelper;
	pageHelper.Initialize(a, b, c, d);
	return pageHelper.GetStartData();
}

extern "C" __declspec(dllexport) int getEndData(int a, int b, int c, int d);
int getEndData(int a, int b, int c, int d)
{
	PageHelper pageHelper;
	pageHelper.Initialize(a, b, c, d);
	return pageHelper.GetEndData();
}

BOOL APIENTRY DllMain( HMODULE hModule,
                       DWORD  ul_reason_for_call,
                       LPVOID lpReserved
                     )
{
    switch (ul_reason_for_call)
    {
    case DLL_PROCESS_ATTACH:
    case DLL_THREAD_ATTACH:
    case DLL_THREAD_DETACH:
    case DLL_PROCESS_DETACH:
        break;
    }
    return TRUE;
}

