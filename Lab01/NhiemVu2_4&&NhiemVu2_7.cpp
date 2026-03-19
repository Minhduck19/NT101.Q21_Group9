	#include<iostream>
	#include<vector>
	#include<map>
	using namespace std;

	// Khai báo mảng chưa PlainText, Key
	vector<char> PlainText;
	vector<char> Key;


	vector<char> BangChuCai = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
	vector< vector<char>> MaTran(5, vector<char>(5));
	vector< pair<char, char>> CipherText;
	vector< pair<char, char>> PlainText2;
	//Mảng chứa vị trí các ký tự của PlainText trong ma trận
	vector<pair<int, int>> ViTriTruocMaHoa;
	vector<pair<int, int>> ViTriSauMaHoa;


	//Mảng chuyển chữ sang số 
	vector<int> Number;
	vector<char> PlainText2_7;

	int ChuyenDoiSo(char c) {
		if (c >= 'A' && c <= 'Z') {
			return c - 'A';
		}
		return -1; // Trả về -1 nếu ký tự không phải là chữ cái
	}


	bool KiemTraLap(vector< vector<char>> Mang, char c) {
		for (int i = 0; i < Mang.size(); i++) {
			for (int j = 0; j < Mang[i].size(); j++) {
				if (c == 'J') c = 'I';
				if (c == 'I' || c == 'J') {
					if(Mang[i][j] == 'I' || Mang[i][j] == 'J') {
						return true;
					}
				}
			
				if (Mang[i][j] == c) {
					return true;
				}
			}
		}
		return false;
	}

	//NHIEM VU 2.4
	void playFair() {
		char c;
		//Nhập PlainText và Key
		cout << "Nhap PlainText: ";
		while (cin.get(c) && c != '\n') {
			PlainText.push_back(c);
		}

		cout << "Nhap Key: ";
		char k;
		while (cin.get(k) && k != '\n') {
			Key.push_back(k);
		}

		//Thêm X nếu PlainText là chuỗi lẻ 
		if (PlainText.size() % 2 != 0) {
			PlainText.push_back('X');
		}

		//Điền vào ma trận 5x5 theo thứ tự của khóa và bảng chữ cái

		int n = 0;
		int m = 0;

		for (int i = 0; i < 5; i++) {
			for (int j = 0; j < 5; j++) {
				while (n < Key.size() && KiemTraLap(MaTran, Key[n])) {
					n++;
				}
				if (n < Key.size()) {
					MaTran[i][j] = Key[n++];
				}
				else {
					while (m < BangChuCai.size() && KiemTraLap(MaTran, BangChuCai[m])) {
						m++;
					}
					MaTran[i][j] = BangChuCai[m++];
				}
			}
		}


		//Lưu vị trí của các ký tự của PlainText trong ma trận
		for (int i = 0; i < PlainText.size(); i++) {
			pair<int, int> temp;
			for (int j = 0; j < 5; j++) {
				for (int o = 0; o < 5; o++) {
					if (MaTran[j][o] == PlainText[i]) {
						temp = { j, o };
						ViTriTruocMaHoa.push_back(temp);
					}
				}
			}
		}


		//Mã hóa
		for (int i = 0; i < ViTriTruocMaHoa.size(); i += 2) {
			pair<char, char> temp;
			if (ViTriTruocMaHoa[i].first == ViTriTruocMaHoa[i + 1].first) {

				if (ViTriTruocMaHoa[i].second == 4) {
					temp = { MaTran[ViTriTruocMaHoa[i].first][0],
							 MaTran[ViTriTruocMaHoa[i].first][ViTriTruocMaHoa[i + 1].second + 1] };
					CipherText.push_back(temp);
				}

				else if (ViTriTruocMaHoa[i + 1].second == 4) {
					temp = { MaTran[ViTriTruocMaHoa[i].first][ViTriTruocMaHoa[i].second + 1],
							 MaTran[ViTriTruocMaHoa[i].first][0] };
					CipherText.push_back(temp);
				}

				else {
					temp = { MaTran[ViTriTruocMaHoa[i].first][ViTriTruocMaHoa[i].second + 1],
							 MaTran[ViTriTruocMaHoa[i].first][ViTriTruocMaHoa[i + 1].second + 1] };
					CipherText.push_back(temp);
				}
			}
			else if (ViTriTruocMaHoa[i].second == ViTriTruocMaHoa[i + 1].second) {
				if (ViTriTruocMaHoa[i].first == 4) {
					temp = { MaTran[0][ViTriTruocMaHoa[i].second],
							 MaTran[ViTriTruocMaHoa[i + 1].first + 1][ViTriTruocMaHoa[i + 1].second] };
					CipherText.push_back(temp);
				}
				else if (ViTriTruocMaHoa[i + 1].first == 4) {
					temp = { MaTran[ViTriTruocMaHoa[i].first + 1][ViTriTruocMaHoa[i].second],
							 MaTran[0][ViTriTruocMaHoa[i + 1].second] };
					CipherText.push_back(temp);
				}
				else {
					temp = { MaTran[ViTriTruocMaHoa[i].first + 1][ViTriTruocMaHoa[i].second],
							 MaTran[ViTriTruocMaHoa[i + 1].first + 1][ViTriTruocMaHoa[i + 1].second] };
					CipherText.push_back(temp);
				}
			}
			else {
				temp = { MaTran[ViTriTruocMaHoa[i].first][ViTriTruocMaHoa[i + 1].second], MaTran[ViTriTruocMaHoa[i + 1].first][ViTriTruocMaHoa[i].second] };
				CipherText.push_back(temp);
			}
		}


		//Lưu vị trí của các ký tự của CipherText trong ma trận
		for (int i = 0; i < CipherText.size(); i++) {
			pair<int, int> temp;
			pair<int, int> temp2;
			bool foundFirst = false;
			for (int j = 0; j < 5; j++) {
				for (int o = 0; o < 5; o++) {
					if (MaTran[j][o] == CipherText[i].first) {
						temp = { j, o };
						ViTriSauMaHoa.push_back(temp);
						foundFirst = true;
					}
					else if (MaTran[j][o] == CipherText[i].second) {
						if(!foundFirst) temp2 = { j, o };
						else {
							temp = { j, o };
							ViTriSauMaHoa.push_back(temp);
							foundFirst = false;
						}
					}
				}
			}
			if (foundFirst) {
				ViTriSauMaHoa.push_back(temp2);	
				foundFirst = false;
			}
		}


		//Giải mã
		for (int i = 0; i < ViTriSauMaHoa.size(); i += 2) {
			pair<char, char> temp;
			if (ViTriSauMaHoa[i].first == ViTriSauMaHoa[i + 1].first) {

				if (ViTriSauMaHoa[i].second == 0) {
					temp = { MaTran[ViTriSauMaHoa[i].first][4],
							 MaTran[ViTriSauMaHoa[i].first][ViTriSauMaHoa[i + 1].second - 1] };
					PlainText2.push_back(temp);
				}

				else if (ViTriSauMaHoa[i + 1].second == 0) {
					temp = { MaTran[ViTriSauMaHoa[i].first][ViTriSauMaHoa[i].second - 1],
							 MaTran[ViTriSauMaHoa[i].first][4] };
					PlainText2.push_back(temp);
				}

				else {
					temp = { MaTran[ViTriSauMaHoa[i].first][ViTriSauMaHoa[i].second - 1],
							 MaTran[ViTriSauMaHoa[i].first][ViTriSauMaHoa[i + 1].second - 1] };
					PlainText2.push_back(temp);
				}
			}
			else if (ViTriSauMaHoa[i].second == ViTriSauMaHoa[i + 1].second) {
				if (ViTriSauMaHoa[i].first == 0) {
					temp = { MaTran[4][ViTriSauMaHoa[i].second],
							 MaTran[ViTriSauMaHoa[i + 1].first - 1][ViTriSauMaHoa[i + 1].second] };
					PlainText2.push_back(temp);
				}
				else if (ViTriSauMaHoa[i + 1].first == 0) {
					temp = { MaTran[ViTriSauMaHoa[i].first - 1][ViTriSauMaHoa[i].second],
							 MaTran[4][ViTriSauMaHoa[i + 1].second] };
					PlainText2.push_back(temp);
				}
				else {
					temp = { MaTran[ViTriSauMaHoa[i].first - 1][ViTriSauMaHoa[i].second],
							 MaTran[ViTriSauMaHoa[i + 1].first - 1][ViTriSauMaHoa[i + 1].second] };
					PlainText2.push_back(temp);
				}
			}
			else {
				temp = { MaTran[ViTriSauMaHoa[i].first][ViTriSauMaHoa[i + 1].second], MaTran[ViTriSauMaHoa[i + 1].first][ViTriSauMaHoa[i].second] };
				PlainText2.push_back(temp);
			}
		}



		//In ma trận
		for (int i = 0; i < MaTran.size(); i++) {
			for (int j = 0; j < MaTran[i].size(); j++) {
				cout << MaTran[i][j] << " ";
			}
			cout << endl;
		}

		//In CipherText
		for (auto x : CipherText) {
			cout << x.first << x.second << " ";
		}
		cout << endl;

		//In PlainText2
		for (auto x : PlainText2) {
			cout << x.first << x.second << " ";
		}


		return;
	}

	//NHIEM VU 2.7
	void Affine() {
		cout << "Nhap PlainText: ";
		char c;
		while(cin.get(c) && c != '\n') {
			PlainText2_7.push_back(c);
		}
		int a, b;
		cout << "Nhap a: ";
		cin >> a;
		cout << "Nhap b: ";
		cin >> b;
		cout << "CipherText: ";	
		for(auto x : PlainText2_7) {
			int num = ChuyenDoiSo(x);
			int cipherNum = (a * num + b) % 26;
			char cipherChar = BangChuCai[cipherNum];
			cout << cipherChar;
		}
	}



	int main() {
		 playFair();
		//Affine();
		return 0;
	}