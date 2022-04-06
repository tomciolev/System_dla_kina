# System_dla_kina
Rozwiązanie, dzięki któremu można obsługiwać rezerwacje miejsc w kinie.

Jest to projekt zrobiony na przedmiot programowanie obiektowe w C#. Zawiera między innymi klasy abstrakcyjne oraz dziedziczące, interfejsy, regexy, serializację, obsługę własnych wyjątków, testy jednostkowe.

GUI w formie aplikacji WPF składa się z głównego okna:

![image](https://user-images.githubusercontent.com/79854074/162072862-e9d2bdad-a6f6-48c4-9af9-d2f27041c4b0.png)

Po wybraniu filmu z listy repertuaru na dany dzień, ukazuje nam się sala z miejscami, które możemy zarezerwować. Po kliknięciu w szczegóły filmu można dowiedzieć się o nim więcej.
Zaznaczamy interesujące nas miejsca i klikamy zakup miejsca.

![image](https://user-images.githubusercontent.com/79854074/162073062-aa86cc31-1f95-4f9c-a376-e06d4a1f67dc.png)

Wtedy otworzy nam się nowe okienko z podsumowanie zarezerwowanych przez nas miejsc. Potwierdzamy swoje dane i wracamy do głównego okienka.

![image](https://user-images.githubusercontent.com/79854074/162073179-71466a71-68e3-44ba-adcb-90e4d751eabf.png)

Jak widać zarezerwowane przez nas miejsca nie są już dostępne.

![image](https://user-images.githubusercontent.com/79854074/162073458-bc1f5929-1fda-4ddb-80c0-5b83e7dd34d2.png)

System serializuje harmonogram seansów, dane klientów sumując ich dotychczasową liczbę zakupionych biletów oraz informacje o sprzedanych biletach - ilości biletów oraz na jaki seans. Do rozwiązania dodany jest także projekt z testami jednostkowymi dla niektórych klas.
