# System_dla_kina
Rozwiązanie, dzięki któremu można obsługiwać rezerwacje miejsc w kinie.

Jest to projekt zrobiony na przedmiot programowanie obiektowe w C#.

GUI w formie aplikacji WPF składa się z głównego okna:

![image](https://user-images.githubusercontent.com/79854074/162071646-55c8991b-5a1e-4b91-b458-e5cb9b3c0fb8.png)

Po wybraniu filmu z listy repertuaru na dany dzień, ukazuje nam się sala z miejscami, które możemy zarezerwować. Po kliknięciu w szczegóły filmu można dowiedzieć się o nim więcej.
Zaznaczamy interesujące nas miejsca i klikamy zakup miejsca.

![image](https://user-images.githubusercontent.com/79854074/162071927-bbf8921d-60bf-4c1c-a979-18f2d5f27898.png)

Klient może wybrać dowolną datę, która go interesuje, zobaczyć szczegóły filmu oraz rozkład wolnych miejsc na sali. Można zarezerwować kilka miejsc jednocześnie.

System serializuje harmonogram seansów, klientów sumując ich dotychczasową liczbę zakupionych biletów oraz informacje o sprzedanych biletach - ilości biletów oraz na jaki seans. 

Do rozwiązania dodany jest także projekt z testami jednostkowymi dla niektórych klas.
