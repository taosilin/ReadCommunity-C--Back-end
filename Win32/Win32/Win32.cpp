// Win32.cpp : 定义 DLL 应用程序的导出函数。
//

#include "stdafx.h"
#include "Win32.h"

PageHelper::PageHelper() {

}

void PageHelper::Initialize(int totalData, int dataPerPage, int currentPage, int pageNum) {
	TotalData = totalData;
	DataPerPage = dataPerPage;
	CurrentPage = currentPage;
	PageNum = pageNum;
	
	//计算总页数
	TotalPages = ceil((TotalData*1.0f) / (DataPerPage*1.0f));
	//计算起始页码
	StartPage = max(1, CurrentPage - (PageNum / 2));
	//计算终止页码
	EndPage = min(TotalPages, CurrentPage + (PageNum / 2));
	//计算起始数据
	StartData = 1 + ((CurrentPage - 1)*DataPerPage);
	//计算终止数据
	EndData = min(TotalData, (CurrentPage*DataPerPage));
}

int PageHelper::GetTotalPages() {
	return TotalPages;
}

int PageHelper::GetStartPage() {
	return StartPage;
}

int PageHelper::GetEndPage() {
	return EndPage;
}

int PageHelper::GetStartData() {
	return StartData;
}

int PageHelper::GetEndData() {
	return EndData;
}

PageHelper::~PageHelper() {
	
}