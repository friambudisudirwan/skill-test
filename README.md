
# Skill Test

Program sederhana untuk menyelesaikan tugas Skill Test yang diberikan. Menggunakan .NET 8.0 Web API. Beberapa program diantaranya **Split and Reverse String,** **Anagram,** **TransactionDiscount.** SwashBuckle digunakan sebagai swagger document object untuk menampilkan kerangka API.


## Split and Reverse String
Karakter yang di-input, split bagian tengah dan di-balik kiri dan kanan. Contoh :
- Input : ABCDEF
- Output : CBAFED

Screenshoot Input :
- ![App Screenshot](https://res.cloudinary.com/dpmo5wjul/image/upload/v1736849324/1daf304b-5047-49a5-9007-bab02e13c5c5.png)

- ![App Screenshot](https://res.cloudinary.com/dpmo5wjul/image/upload/v1736849556/cec4aacd-0893-4567-a776-fe978b7e515d.png)

Screenshoot Output :
- ![App Screenshot](https://res.cloudinary.com/dpmo5wjul/image/upload/v1736849507/9da51ed9-a259-44ac-bbe0-e3a4c0044c6e.png)

- ![App Screenshot](https://res.cloudinary.com/dpmo5wjul/image/upload/v1736849600/b1289e21-326a-4408-aa51-dcdd55597d7d.png)

## Anagram
Dua kata dianggap anagram jika dengan menata ulang huruf dari kata pertama. Misalnya **cinema** dan **iceman** adalah anagram (menghasilkan output **1** apabila anagram, **0** bila tidak).

**Constraints** : Semua kata hanya berisi huruf kecil (a-z).

Screenshoot Input :
- ![App Screenshot](https://res.cloudinary.com/dpmo5wjul/image/upload/v1736850248/fb9a13c2-bad7-4859-92bd-80d01c5c7ed1.png)

Screenshoot Output :
- ![App Screenshot](https://res.cloudinary.com/dpmo5wjul/image/upload/v1736850318/35f965c0-e731-41c2-9d12-0fe9168abb09.png)

## Transaction Discount
Program sederhana untuk menghitung diskon dengan ketentuan yang sudah ditentukan. Data penghitungan discount disimpan ke database, dengan format id transaksi **yyyyMMdd_00001**(00001 => running number).

Screenshoot Input :
- ![App Screenshot](https://res.cloudinary.com/dpmo5wjul/image/upload/v1736850770/ef6ed68e-ffa0-48cc-a405-340737bc353b.png)

Screenshoot Output :
- ![App Screenshot](https://res.cloudinary.com/dpmo5wjul/image/upload/v1736850940/fed42f44-2e60-43d9-a13a-c5af0f22bb9b.png)

Output disimpan ke dalam database menggunakan **Entity Framework Core** dengan database **SQL Server**.
![App Screenshot](https://res.cloudinary.com/dpmo5wjul/image/upload/v1736851185/5b49348e-6d0d-41ba-942b-9e142dca82f2.png)

## Database Configuration
Untuk saat ini, belum ada engine untuk migrasi database secara otomatis. Untuk testing, maka diperlukan pembuatan database dan table secara manual terlebih dahulu menggunakan **SQL Server**.
Sesuaikan nama database dengan format connectionstring di `appsettings.json` dan buat table dengan nama `Transaction`.

## Struktur Table

| Color             | Hex                                                                |
| ----------------- | ------------------------------------------------------------------ |
| TransaksiID | varchar(255) not null primary key |
| TipeCustomer | varchar(255) |
| PointReward | int |
| TotalBelanja | float |
| Diskon | float |
| TotalBayar | float |
