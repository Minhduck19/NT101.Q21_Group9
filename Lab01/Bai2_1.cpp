#include <iostream>
#include <sstream>
#include <vector>
using namespace std;

int countMeaningfulWords(string text){
    vector<string> dict = {
        "the","be","to","of","and","a","in","that","have","i",
        "it","for","not","on","with","he","as","you","do","at",
        "this","but","his","by","from","hello","world"
    };

    string word;
    stringstream ss(text);
    int count = 0;

    while(ss >> word){
        for(string d : dict){
            if(word == d){
                count++;
            }
        }
    }

    return count;
}

int main(){
    string CeasarPlainText, CeasarCipherText;
    int CeasarKey;

    cout << "Vui long chon:" << endl;
    cout << "1. Ma hoa Ceasar" << endl;
    cout << "2. Giai ma Ceasar" << endl;

    int choice;
    cin >> choice;

    if (choice == 1){

        cout << "Nhap ban ro: ";
        cin.ignore();
        getline(cin, CeasarPlainText);

        cout << "Nhap khoa: ";
        cin >> CeasarKey;

        string CeasarCipherText="";

        for (int i = 0; i < CeasarPlainText.length(); i++){
            if (CeasarPlainText[i] >= 'a' && CeasarPlainText[i] <= 'z'){
                CeasarCipherText += (CeasarPlainText[i] - 'a' + CeasarKey) % 26 + 'a';
            }
            else if (CeasarPlainText[i] >= 'A' && CeasarPlainText[i] <= 'Z'){
                CeasarCipherText += (CeasarPlainText[i] - 'A' + CeasarKey) % 26 + 'A';
            }
            else{
                CeasarCipherText += CeasarPlainText[i];
            }
        }

        cout << "Ban ma: " << CeasarCipherText << endl;
    }

    else if (choice == 2){

        cout << "Nhap ban ma: ";
        cin.ignore();
        getline(cin, CeasarCipherText);

        int bestKey = 0;
        int bestScore = -1;
        string bestText;

        for(int i = 1 ; i <= 25; i++){

            CeasarPlainText = "";

            for (int j = 0; j < CeasarCipherText.length(); j++){
                if (CeasarCipherText[j] >= 'a' && CeasarCipherText[j] <= 'z'){
                    CeasarPlainText += (CeasarCipherText[j] - 'a' - i + 26) % 26 + 'a';
                }
                else if (CeasarCipherText[j] >= 'A' && CeasarCipherText[j] <= 'Z'){
                    CeasarPlainText += (CeasarCipherText[j] - 'A' - i + 26) % 26 + 'A';
                }
                else{
                    CeasarPlainText += CeasarCipherText[j];
                }
            }

            int score = countMeaningfulWords(CeasarPlainText);

            cout << "Khoa: " << i 
                 << " - Ban ro: " << CeasarPlainText
                 << " (score=" << score << ")" << endl;

            if(score > bestScore){
                bestScore = score;
                bestKey = i;
                bestText = CeasarPlainText;
            }
        }

        cout << endl;
        cout << "=== Ket qua tot nhat ===" << endl;
        cout << "Khoa: " << bestKey << endl;
        cout << "Ban ro: " << bestText << endl;
    }

    else{
        cout << "Lua chon khong hop le!" << endl;
    }

    return 0;
}