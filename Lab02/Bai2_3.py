from Crypto.Cipher import DES
import binascii

def count_bit_difference(data1, data2):
    int1 = int.from_bytes(data1, byteorder='big')
    int2 = int.from_bytes(data2, byteorder='big')
    diff = int1 ^ int2
    return bin(diff).count('1')

def avalanche_test(student_id_key):
    
    key = student_id_key.encode().ljust(8, b'\0')[:8]
    cipher = DES.new(key, DES.MODE_ECB)

    p1 = b'STAYHOME'
    p2 = b'STAYHOMA' 

   
    c1 = cipher.encrypt(p1)
    c2 = cipher.encrypt(p2)

   
    bit_diff = count_bit_difference(c1, c2)
    total_bits = len(c1) * 8
    percentage = (bit_diff / total_bits) * 100

    print(f"Key (MSSV): {student_id_key}")
    print(f"Ciphertext 1 (Hex): {c1.hex()}")
    print(f"Ciphertext 2 (Hex): {c2.hex()}")
    print(f"Số bit khác nhau: {bit_diff}/{total_bits}")
    print(f"Tỷ lệ thay đổi: {percentage:.2f}%")


avalanche_test("24520332")