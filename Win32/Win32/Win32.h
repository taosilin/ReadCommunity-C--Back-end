#pragma once
#include<iostream>
#include<cstdlib>

using namespace std;

class PageHelper
{
public:
	PageHelper();
	void Initialize(int totalData, int dataPerPage, int currentPage, int pageNum);
	int GetTotalPages();
	int GetStartPage();
	int GetEndPage();
	int GetStartData();
	int GetEndData();
	~PageHelper();
private:
	int TotalData;//数据总数
	int TotalPages;//总页数
	int DataPerPage;//每页数据量
	int CurrentPage;//当前页
	int PageNum;//显示的页码数
	int StartPage;//起始页码//从1开始
	int EndPage;//末尾页页码
	int StartData;//当前页起始数据//假设从1开始
	int EndData;//当前页末尾数据
};
