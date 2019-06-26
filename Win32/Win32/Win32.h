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
	int TotalData;//��������
	int TotalPages;//��ҳ��
	int DataPerPage;//ÿҳ������
	int CurrentPage;//��ǰҳ
	int PageNum;//��ʾ��ҳ����
	int StartPage;//��ʼҳ��//��1��ʼ
	int EndPage;//ĩβҳҳ��
	int StartData;//��ǰҳ��ʼ����//�����1��ʼ
	int EndData;//��ǰҳĩβ����
};
