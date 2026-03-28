#include <iostream>
#include <string>
#include <algorithm>
#include <vector>
using namespace std;
void pb1()
{
	string sir;
	char l1;
	char l2;
	cout << "introduceti sirul: ";
	getline(cin, sir);
	cout << "Introduceti litera l1: ";
	cin >> l1;
	cout << "Introduceti litera l2: ";
	cin >> l2;
	for (int i = 0; i < sir.size(); i++) {
		if (sir[i] == l1)
			sir[i] = l2;
		else if (sir[i] == l2)
			sir[i] = l1;
	}
	cout << "Sirul final transcris: " << sir << endl;

}

void pb2()
{
	string text;
	cout << "introduceti textul: ";
	getline(cin, text);
	string cuv = "";
	int spatii = 0;
	for (int i = 0;i < text.size();i++)
	{
		if (text[i] != ' ')
		{
			if (spatii >= 2 && !cuv.empty())
			{
				cout << cuv << endl;
				cuv = "";

			}
			cuv += text[i];
			spatii = 0;
		}
		else 
		{
			spatii++;
		}
		
	}
	cout << cuv << endl;
}

void pb3()
{
	string text;
	cout << "introduceti textul: ";
	getline(cin, text);

	string textfin = "";
	bool incuv = false;   
	int lungimetextfin = 0;
	for (int i = 0;i < text.size();i++)
	{
		if (text[i] != ' ') {
			textfin += text[i];
			incuv = true;
			lungimetextfin++;
		}
		else 
		{
			if (incuv) {
				textfin += ' ';
				lungimetextfin++;
				incuv = false;
			}
		}
	}
	cout << "textul final: " << textfin << endl;
}

void pb4()
{
	string text;
	cout << "Introduceti textul: ";
	getline(cin, text);

	vector<string> cuvinte;
	string cuvant = "";
	bool inCuvant = false;

	
	for (int i = 0; i < text.size(); i++) {
		if (text[i] != ' ') {
			cuvant += text[i];
			inCuvant = true;
		}
		else {
			if (inCuvant) { 
				cuvinte.push_back(cuvant);
				cuvant = "";
				inCuvant = false;
			}
		}
	}

	if (inCuvant) {
		cuvinte.push_back(cuvant);
	}

	
	sort(cuvinte.begin(), cuvinte.end());

	
	cout << "Cuvintele ordonate alfabetic:\n";
	for (int i = 0; i < cuvinte.size(); i++) {
		cout << cuvinte[i] << endl;
	}

	
}

int main()
{
	//pb1();
	//pb2();
	//pb3();
	pb4();
}

