# PrzetwarzanieOperatow
Przetwarzanie operatów w PDF - program napisany dla konkursu GUGiK: <br>
[Informacje o konkursie](http://www.gugik.gov.pl/bip/zamowienia-publiczne/2022-o-wartosci-ponizej-130-000,00-zlotych/opracowanie-aplikacji-sluzacej-do-zarzadzaniaprzetwarzania-dokumentacji-w-formacie-pdf)
<br>
Program działa zarówno w konsoli jak i w zaprojektowanym GUI. Obsługuje pliki w formatach:<br>
<br><b>PDF:</b> *.pdf
<br><b>Graficzne:</b> *.jpg, *.png, *.bmp, *.tiff
<br><b>Word:</b> *.doc, *.docx, *.docm
<br><b>Excel:</b> *.xls, *.xlsx, *.xlsm

 ### Wykorzystano w nim następujące biblioteki:
- [barcodelib](https://github.com/barnhill/barcodelib)
- [GhostScript.NET](https://github.com/jhabjan/Ghostscript.NET)
- [GhostScript](https://www.ghostscript.com/)
- [PDFsharp](http://www.pdfsharp.net/)
- [Magick.NET](https://github.com/dlemstra/Magick.NET)

## Tryb GUI
Obsługa programu z poziomu GUI daje wiele możliwości konfiguracji przetwarzanych plików, poniżej znajduje się krótki opis możliwości:

### Okno główne 
<br>
<p align="center">
<img src="Opis Ikony/MainWindow.png" Width=600>
</p>

#### Możliwość wyboru:
 - Wybranie okładki i jej edycję
 - Dodanie pojedynczego lub wielu plików do łączenia
 - Modyfikację kolejności łączenia lub usuwanie elementów z listy
 - Dostosowanie parametrów łączenia

<br>
<hr>

### Parametry przetwarzania plików
<br>
<p align="center">
<img src="Opis Ikony/Ustawienia Łączenia.png">
</p>


#### Konfiguracja:
 - Wybranie stopnia kompresjii pliku w celu zmiejszenia jego rozmiarów
 - Dodanie wybranego tekstu na każdej stronie
 - Numeracja połączonych stron

<br>
<hr>

### Ustawienia główne programu
<br>
<p align="center">
<img src="Opis Ikony/Ustawienia główne.png">
</p>


#### Parametry:
 - Wczytywanie wybranych ustawień po starcie programu
 - Zapisywanie parametrów łączenia plików - umożliwia to zapis paramterów przetwarzania do pliku i późniejszy odczyt konfiguracji
 - Wybranie domyślnej okładki
 - Ustawienie przedrostku do kodu kreskowego
 
<br>
<hr>

### Edycja okładki lub innego pliku
<br>
<p align="center">
<img src="Opis Ikony/Edycja strony.png" Width=400 Height=300>
<img src="Opis Ikony/Edycja pliku.png" Width=400 Height=300>
</p>


#### Możliwości edycji:
 - Dodawanie kodu kreskowego
 - Dodawania obrazu
 - Dodawanie tekstu
 - Zapisanie zedytowanego pliku do osobnego pliku
 <br>
<hr>

### Przetwarzanie pliku
<br>
<p align="center">
<img src="Opis Ikony/Przetwarzanie.png" Width=600>
</p>

#### Informacje
 - Ilość przetwarzanych plików 
 - Łączna ilość stron w nowym pliku
 - Informacja o przetwarzaniu wynikowego pliku przez ghostscript
 
 ## Tryb GUI
Obsługa programu z poziomu konolowego daje podobne możliwości konfiugarcji ręcznej, lub wczytanie pliku konfiguracyjnego utworzonego w GUI.<br>
Menu główne prezentuje się następująco:
<br>
<p align="center">
<img src="Opis Ikony/Menu konsoli.png" Width=600>
</p>
<br>
Wybranie któregoś z elementów wyświetli kolejne opcje do wyboru.

## Autor
<b>Damian Zacheja</b>

## Licencja
[MIT](https://github.com/DZacheja/PrzetwarzanieOperatow/blob/master/LICENSE)

 
