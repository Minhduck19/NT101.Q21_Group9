#include <iostream>
#include <string>
using namespace std;

// Hàm chuẩn hóa: chuyển về chữ hoa và bỏ ký tự không phải chữ
string normalize(string s){
    string result = "";
    for(char c : s){
        if(isalpha(c)){
            result += toupper(c);
        }
    }
    return result;
}

// Hàm tạo key lặp lại theo độ dài bản rõ
string generateKey(string text, string key){
    int j = 0;
    string newKey = "";

    for(int i = 0; i < text.length(); i++){
        newKey += key[j];
        j = (j + 1) % key.length();
    }

    return newKey;
}

// Hàm mã hóa
string encrypt(string text, string key){
    string cipher = "";

    for(int i = 0; i < text.length(); i++){
        char c = ((text[i] - 'A') + (key[i] - 'A')) % 26 + 'A';
        cipher += c;
    }

    return cipher;
}

// Hàm giải mã
string decrypt(string cipher, string key){
    string text = "";

    for(int i = 0; i < cipher.length(); i++){
        char c = ((cipher[i] - key[i] + 26) % 26) + 'A';
        text += c;
    }

    return text;
}

int main(){
    int choice;
    string text, key;

    cout << "1. Ma hoa Vigenere\n";
    cout << "2. Giai ma Vigenere\n";
    cout << "Chon: ";
    cin >> choice;
    cin.ignore();

    cout << "Nhap key: ";
    getline(cin, key);
    key = normalize(key);

    if(choice == 1){
        cout << "Nhap plaintext: ";
        getline(cin, text);
        text = normalize(text);

        string newKey = generateKey(text, key);
        string cipher = encrypt(text, newKey);

        cout << "Ciphertext: " << cipher << endl;
    }
    else if(choice == 2){
        cout << "Nhap ciphertext: ";
        getline(cin, text);
        text = normalize(text);

        string newKey = generateKey(text, key);
        string plain = decrypt(text, newKey);

        cout << "Plaintext: " << plain << endl;
    }

    return 0;
}