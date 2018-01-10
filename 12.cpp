#include <iostream>

using namespace std;

int main (){
	int sum,prod;
	cin>>sum>>prod;
	for (int i = 1; i < 1002; ++i){
		for (int j = 1; j < 1002; ++j){
			if (i+j==sum and i*j==prod){
				cout<<i<<" "<<j;
				return 0;
			}
		}
	}
	return 0;
}