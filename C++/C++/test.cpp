#include "test.h"
#include <stdio.h>

int _stdcall sum(int a, int b) 
{
	return a + b;
}

float _stdcall calc(float old_score, int old_rating, int score)
{
	float new_score = 2 * (old_score * old_rating + score) / (old_rating + 1);
	return new_score;
}