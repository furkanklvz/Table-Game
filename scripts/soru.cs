using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class soru : MonoBehaviour
{
    public TextMeshProUGUI soru_, secenek1, secenek2, secenek3, secenek4, secenek5, sure, zorluk, dogru, yanlıs, sira, skor, zarSira, winner, oyunSonuPuanlari, player;
    char cvp;
    public GameObject red, green, soruPaneli, zarPaneli, zarObject, cam, hazirPaneli;
    public Button butonA, butonB, butonC, butonD, butonE;
    public AudioSource correct, wrong, tikTak;
    int redPoint = 0;
    public float speed = 0.01f;
    int greenPoint = 0;
    bool isRedTurn = true;
    bool tikTakOn = true;
    bool stopTimer = false;
    bool ilkTur = true;
    bool butonDevrede = true;
    bool tekrar = false;
    bool besSaniye = true;
    [SerializeField] int whereIsRed = 0;
    int[] bannedQuestions = new int[24];
    int x;
    int indexOfBannedQuestions = 0;
    [SerializeField] int whereIsGreen = 0;
    bool piyonHareketiOn = false;
    bool zarAktif = true;
    public TextMeshProUGUI cekilenSayi;
    public static int random;
    Vector3 rotating;
    public GameObject cpK0, cpK1, cpK2, cpK3, cpK4, cpK5, cpK6, cpK7, cpK8, cpK9, cpK10, cpK11, cpK12, cpK13, cpK14, cpK15, cpK16, cpK17, cpK18, cpK19, cpK20, cpK21, cpK22, cpK23, cpK24, cpK25, cpK26, cpK27, cpK28, cpK29;
    public GameObject cpK30, cpK31, cpK32, cpK33, cpK34, cpK35, cpK36, cpK37, cpK38, cpK39, cpK40, cpK41, cpK42, cpK43, cpK44, cpK45, cpK46, cpK47, cpK48, cpK49, cpK50, cpK51, cpK52, cpK53, cpK54, cpK55, cpK56;
    public GameObject cpY0, cpY1, cpY2, cpY3, cpY4, cpY5, cpY6, cpY7, cpY8, cpY9, cpY10, cpY11, cpY12, cpY13, cpY14, cpY15, cpY16, cpY17, cpY18, cpY19, cpY20, cpY21, cpY22, cpY23, cpY24, cpY25, cpY26, cpY27, cpY28, cpY29;
    public GameObject cpY30, cpY31, cpY32, cpY33, cpY34, cpY35, cpY36, cpY37, cpY38, cpY39, cpY40, cpY41, cpY42, cpY43, cpY44, cpY45, cpY46, cpY47, cpY48, cpY49, cpY50, cpY51, cpY52, cpY53, cpY54, cpY55, cpY56;
    void Start()
    {
        soruPaneli.SetActive(false);
        zarPaneli.SetActive(false);
        dogru.text = "";
        yanlıs.text = "";
        player.text = "KIRMIZI OYUNCU";
        player.color = Color.red;
    }
    void Update()
    {
        if (piyonHareketiOn)
        {
            piyonHareketi();
            if (besSaniye)
            {
                StartCoroutine(ikiSaniyeC());
                besSaniye = false;
            }
        }
    }
    public void hazir()
    {
        hazirPaneli.SetActive(false);
        soruPaneli.SetActive(true);
        soruGetir();
        butonA.image.color = Color.white;
        butonB.image.color = Color.white;
        butonC.image.color = Color.white;
        butonD.image.color = Color.white;
        butonE.image.color = Color.white;
    }
    public void soruGetir()
    {
        butonDevrede = true;
        sure.color = Color.white;
        stopTimer = false;
        if (isRedTurn)
        {
            sira.text = "Sıra Kırmızıda";
            sira.color = Color.red;
        }
        else
        {
            sira.text = "Sıra Yeşilde";
            sira.color = Color.green;
        }
        dogru.text = "";
        yanlıs.text = "";
        tekrar = false;
        do
        {
            x = Random.Range(1, 26);
            for (int i = 0; i < 24; i++)
            {
                if (x != bannedQuestions[i])
                {
                    tekrar = false;
                }
                else
                {
                    tekrar = true;
                    Debug.Log("Aynı Soru emgellendi");
                    break;
                }
            }

        } while (tekrar);
        bannedQuestions[indexOfBannedQuestions] = x;
        indexOfBannedQuestions++;
        switch (x)
        {
            case 1:
                soru_.text = "Eskici adlı öyküdeki baş kahramanın (çocuğun) ismi nedir?";
                secenek1.text = "Osman";
                secenek2.text = "Hasan";
                secenek3.text = "Muzaffer";
                secenek4.text = "Kazım";
                secenek5.text = "Ali";
                zorluk.text = "Zorluk: KOLAY";
                cvp = 'b';
                StartCoroutine(timer(0));
                break;
            case 2:
                soru_.text = "'Eskici' adlı öyküde kahraman (çocuk) hangi araçla yolculuk yapmaktadır?";
                secenek1.text = "Traktör";
                secenek2.text = "Kağnı";
                secenek3.text = "Vapur";
                secenek4.text = "Otobüs";
                secenek5.text = "Tren";
                zorluk.text = "Zorluk: ORTA";
                cvp = 'b';
                StartCoroutine(timer(1));
                break;
            case 3:
                soru_.text = "'Felatun Bey ile Rakım Efendi' adlı romandaki Felatun ismi, hangi Yunan filozofunun adından esinlenilerek oluşturulmuştur";
                secenek1.text = "Sokrates";
                secenek2.text = "Philon";
                secenek3.text = "Platon";
                secenek4.text = "Aristotales";
                secenek5.text = "Thales";
                zorluk.text = "Zorluk: ZOR";
                cvp = 'c';
                StartCoroutine(timer(2));
                break;
            case 4:
                soru_.text = "Aşağıdaki eserlerden hangisi Cengiz Dağcı'nın diğer romanlarından biridir?";
                secenek1.text = "Cemile";
                secenek2.text = "Anneme Mektuplar";
                secenek3.text = "Kiralık Konak";
                secenek4.text = "Yalnızız";
                secenek5.text = "Kuyruklu Yıldız Altında İzdivaç";
                zorluk.text = "Zorluk: ZOR";
                cvp = 'b';
                StartCoroutine(timer(2));
                break;
            case 5:
                soru_.text = "'Araba Sevdası' adlı romanın ana teması aşağıdakilerden hangisidir?";
                secenek1.text = "Kıskançlık";
                secenek2.text = "Aşırı tüketim eğilimi";
                secenek3.text = "Marka düşkünlüğü";
                secenek4.text = "Bilinçsiz batılılaşma";
                secenek5.text = "Yoksulluk";
                zorluk.text = "Zorluk: ORTA";
                cvp = 'd';
                StartCoroutine(timer(1));
                break;
            case 6:
                soru_.text = "Aşağıdaki isimlerden hangisi Yaban romanının başkahramanıdır?";
                secenek1.text = "Musa Çelebi";
                secenek2.text = "Ahmet Celal";
                secenek3.text = "Çolak Salih";
                secenek4.text = "Tatar Ramazan";
                secenek5.text = "Faiz Bey";
                zorluk.text = "Zorluk: KOLAY";
                cvp = 'b';
                StartCoroutine(timer(0));
                break;
            case 7:
                soru_.text = "Yaban romanının konusu aşağıdaki bölgelerden hangisinde geçmektedir?";
                secenek1.text = "Ege";
                secenek2.text = "Doğu Anadolu";
                secenek3.text = "İç Anadolu";
                secenek4.text = "Akdeniz";
                secenek5.text = "Marmara";
                zorluk.text = "Zorluk: ORTA";
                cvp = 'c';
                StartCoroutine(timer(1));
                break;
            case 8:
                soru_.text = "Aşağıdakilerden hangisi Yaban romanının ana teması olarak kabul edilebilir?";
                secenek1.text = "Halkı ezen ağalık düzeni";
                secenek2.text = "Angarya zulmü";
                secenek3.text = "Eşitsizlik";
                secenek4.text = "Halkın eğitimi ve cehaletten kurtarılması";
                secenek5.text = "Geri kalmışlık";
                zorluk.text = "Zorluk: ZOR";
                cvp = 'd';
                StartCoroutine(timer(2));
                break;
            case 9:
                soru_.text = "Cengiz Aytmatov’un “Beyaz Gemi” aldı romanındaki öne çıkan hayvan aşağıdakilerden hangisidir?";
                secenek1.text = "Kurt";
                secenek2.text = "Koyun";
                secenek3.text = "Geyik (Maral)";
                secenek4.text = "Tavşan";
                secenek5.text = "Aslan";
                zorluk.text = "Zorluk: ORTA";
                cvp = 'b';
                StartCoroutine(timer(1));
                break;
            case 10:
                soru_.text = "Aşağıdaki isimlerden hangisi Fatih Harbiye romanının kadın kahramanıdır?";
                secenek1.text = "Neriman";
                secenek2.text = "Candan";
                secenek3.text = "Suat";
                secenek4.text = "Feride";
                secenek5.text = "Handan";
                zorluk.text = "Zorluk: ORTA";
                cvp = 'a';
                StartCoroutine(timer(1));
                break;
            case 11:
                soru_.text = "'Kaşağı' adlı öykünün yazarı aşağıdakilerde hangisidir?";
                secenek1.text = "Ziya Gökalp";
                secenek2.text = "Rıza Tevfik";
                secenek3.text = "Ahmet Hamdi Tanpınar";
                secenek4.text = "Ömer Seyfettin";
                secenek5.text = "Aka Gündüz";
                zorluk.text = "Zorluk: KOLAY";
                cvp = 'd';
                StartCoroutine(timer(0));
                break;
            case 12:
                soru_.text = "Fatih Harbiye’deki Fatih semti aşağıdakilerden hangisini temsil etmektedir?";
                secenek1.text = "Batı tipi yaşam tarzını";
                secenek2.text = "Lüks eğlence mekânlarını";
                secenek3.text = "Aşırı bireyleşmeyi";
                secenek4.text = "Doğuyu ve geleneksel hayatı tarzını";
                secenek5.text = "Zenginlik ve şatafat";
                zorluk.text = "Zorluk: ZOR";
                cvp = 'd';
                StartCoroutine(timer(2));
                break;
            case 13:
                soru_.text = "Fatih Harbiye romanının Şinasi’sinin en belirgin özelliği aşağıdakilerden hangisidir?";
                secenek1.text = "Paraya ve kumara düşkün olması";
                secenek2.text = "Dış görünüşüne aşırı önem vermesi";
                secenek3.text = "Doğu medeniyetinin değerlerini temsil etmesi";
                secenek4.text = "Kendini beğenmiş biri olması";
                secenek5.text = "Türk musikisinden nefret etmesi";
                zorluk.text = "Zorluk: ZOR";
                cvp = 'c';
                StartCoroutine(timer(2));
                break;
            case 14:
                soru_.text = "'Beyaz Gemi' romanının kutsal hayvanı aşağıdakilerden hangisidir?";
                secenek1.text = "Kurt";
                secenek2.text = "Koyun";
                secenek3.text = "Geyik (Maral)";
                secenek4.text = "Tavşan";
                secenek5.text = "Arslan";
                zorluk.text = "Zorluk: ORTA";
                cvp = 'c';
                StartCoroutine(timer(1));
                break;
            case 15:
                soru_.text = "Beyaz Gemi romanının Mümin Dede’si aşağıdakilerden hangisini temsil eder?";
                secenek1.text = "Değerleri ve gelenekleri";
                secenek2.text = "Sovyet rejimine sadakati";
                secenek3.text = "Yozlaşmayı";
                secenek4.text = "Fırsatlara göre tutum belirlemeyi";
                secenek5.text = "Alkol bağımlılığını";
                zorluk.text = "Zorluk: ORTA";
                cvp = 'a';
                StartCoroutine(timer(1));
                break;
            case 16:
                soru_.text = "Eskici adlı öyküdeki kahraman (çocuk) nereye gitmektedir?";
                secenek1.text = "Filistin";
                secenek2.text = "Yemen";
                secenek3.text = "Bağdat";
                secenek4.text = "Mısır";
                secenek5.text = "Türkiye";
                zorluk.text = "Zorluk: KOLAY";
                cvp = 'a';
                StartCoroutine(timer(0));
                break;
            case 17:
                soru_.text = "Eskici adlı öyküde kahraman-çocuk hangi akrabasının yanına gitmektedir?";
                secenek1.text = "Dayı";
                secenek2.text = "Amca";
                secenek3.text = "Teyze";
                secenek4.text = "Hala";
                secenek5.text = "Dede";
                zorluk.text = "Zorluk: ORTA";
                cvp = 'd';
                StartCoroutine(timer(1));
                break;
            case 18:
                soru_.text = "Eskici adlı öyküde Hasan dışındaki karakterler hangi dilde konuşmaktadır?";
                secenek1.text = "Farsça";
                secenek2.text = "Arapça";
                secenek3.text = "Fransızca";
                secenek4.text = "İngilizce";
                secenek5.text = "Türkçe";
                zorluk.text = "Zorluk: ORTA";
                cvp = 'b';
                StartCoroutine(timer(1));
                break;
            case 19:
                soru_.text = "Eskici adlı hikayede Hasan Filistin’e hangi şehrimizden gelmiştir?";
                secenek1.text = "Bursa";
                secenek2.text = "Şanlıurfa";
                secenek3.text = "İstanbul";
                secenek4.text = "Ankara";
                secenek5.text = "Samsun";
                zorluk.text = "Zorluk: KOLAY";
                cvp = 'c';
                StartCoroutine(timer(0));
                break;
            case 20:
                soru_.text = "Semaver adlı öyküdeki kahramanın adı nedir?";
                secenek1.text = "Ali";
                secenek2.text = "Hasan";
                secenek3.text = "Murat";
                secenek4.text = "Fatih";
                secenek5.text = "Süleyman";
                zorluk.text = "Zorluk: KOLAY";
                cvp = 'a';
                StartCoroutine(timer(0));
                break;
            case 21:
                soru_.text = "Kaşağı adlı hikâyede kim kime suç atmaktadır?";
                secenek1.text = "Ömer Hasan'a";
                secenek2.text = "Hasan Ömer'e";
                secenek3.text = "Hasan Pervin'e";
                secenek4.text = "Dadaruh Pervin'e";
                secenek5.text = "Ömer Dadaruh'a";
                zorluk.text = "Zorluk: ORTA";
                cvp = 'a';
                StartCoroutine(timer(1));
                break;
            case 22:
                soru_.text = "Kaşağı adlı hikayede Ömer ve Hasan çocukluklarını nerede geçirmişlerdir?";
                secenek1.text = "Köyde";
                secenek2.text = "Kasabada";
                secenek3.text = "Şehir Merkezinde";
                secenek4.text = "Köşkte";
                secenek5.text = "Çiftlikte";
                zorluk.text = "Zorluk: ORTA";
                cvp = 'e';
                StartCoroutine(timer(1));
                break;
            case 23:
                soru_.text = "Ömer ve Hasan’ın kullandığı Kaşağı nereden özel olarak gelmiştir?";
                secenek1.text = "İstanbul";
                secenek2.text = "Bursa";
                secenek3.text = "Samsun";
                secenek4.text = "Fransa";
                secenek5.text = "İzmir";
                zorluk.text = "Zorluk: ZOR";
                cvp = 'a';
                StartCoroutine(timer(2));
                break;
            case 24:
                soru_.text = "“Kaşağı” adlı öykünün ana teması aşağıdakilerden hangisidir?";
                secenek1.text = "Hayvan sevgisi";
                secenek2.text = "Vicdan azabı";
                secenek3.text = "İnsan sevgisi";
                secenek4.text = "Adalet";
                secenek5.text = "Eşitsizlik";
                zorluk.text = "Zorluk: ORTA";
                cvp = 'b';
                StartCoroutine(timer(1));
                break;
            case 25:
                soru_.text = "‘Eskici’ adlı öykünün yazarı aşağıdaki isimlerden hangisidir?";
                secenek1.text = "Ömer Seyfettin";
                secenek2.text = "Sait Faik Abasıyanık";
                secenek3.text = "Refik Halit Karay";
                secenek4.text = "Murathan Mungan";
                secenek5.text = "Mustafa Kutlu";
                zorluk.text = "Zorluk: ORTA";
                cvp = 'c';
                StartCoroutine(timer(1));
                break;
        }
    }
    public void clickA()
    {
        if (butonDevrede)
        {
            StartCoroutine(buttonA());
        }
    }
    public void clickB()
    {
        if (butonDevrede)
        {
            StartCoroutine(buttonB());
        }
    }
    public void clickC()
    {
        if (butonDevrede)
        {
            StartCoroutine(buttonC());
        }
    }
    public void clickD()
    {
        if (butonDevrede)
        {
            StartCoroutine(buttonD());
        }
    }
    public void clickE()
    {
        if (butonDevrede)
        {
            StartCoroutine(buttonE());
        }
    }
    public IEnumerator buttonA()
    {
        butonDevrede = false;
        tikTak.Stop();
        stopTimer = true;
        if (cvp == 'a')
        {
            butonA.image.color = Color.green;
            correct.Play();
            if (zorluk.text == "Zorluk: ZOR")
            {
                dogru.text = "Doğru Cevap\n+30 Puan";
                if (isRedTurn == true)
                {
                    redPoint += 30;
                    if (ilkTur)
                    {
                        ilkTur = false;
                        yield return new WaitForSeconds(2);
                        isRedTurn = false;
                        player.text = "YEŞİL OYUNCU";
                        player.color = Color.green;
                        soruPaneli.SetActive(false);
                        hazirPaneli.SetActive(true);
                        yield break;
                    }
                }
                else
                {
                    greenPoint += 30;
                }
            }
            else if (zorluk.text == "Zorluk: ORTA")
            {
                dogru.text = "Doğru Cevap\n+20 Puan";
                if (isRedTurn == true)
                {
                    redPoint += 20;
                    if (ilkTur)
                    {
                        ilkTur = false;
                        yield return new WaitForSeconds(2);
                        isRedTurn = false;
                        player.text = "YEŞİL OYUNCU";
                        player.color = Color.green;
                        soruPaneli.SetActive(false);
                        hazirPaneli.SetActive(true);
                        yield break;
                    }
                }
                else
                {
                    greenPoint += 20;
                }
            }
            else
            {
                dogru.text = "Doğru Cevap\n+10 Puan";
                if (isRedTurn == true)
                {
                    redPoint += 10;
                    if (ilkTur)
                    {
                        ilkTur = false;
                        yield return new WaitForSeconds(2);
                        isRedTurn = false;
                        player.text = "YEŞİL OYUNCU";
                        player.color = Color.green;
                        soruPaneli.SetActive(false);
                        hazirPaneli.SetActive(true);
                        yield break;
                    }
                }
                else
                {
                    greenPoint += 10;
                }
            }
        }
        else
        {
            butonA.image.color = Color.red;
            switch (cvp)
            {
                case 'b':
                    butonB.image.color = Color.green;
                    break;
                case 'c':
                    butonC.image.color = Color.green;
                    break;
                case 'd':
                    butonD.image.color = Color.green;
                    break;
                case 'e':
                    butonE.image.color = Color.green;
                    break;
            }
            wrong.Play();
            yanlıs.text = "Yanlış Cevap";
            if (isRedTurn == true)
            {
                if (ilkTur)
                {
                    ilkTur = false;
                    yield return new WaitForSeconds(2);
                    isRedTurn = false;
                    player.text = "YEŞİL OYUNCU";
                    player.color = Color.green;
                    soruPaneli.SetActive(false);
                    hazirPaneli.SetActive(true);
                    yield break;
                }
            }
        }
        yield return new WaitForSeconds(2);
        skor.text = "Kırmızı: " + redPoint + "\nYeşil: " + greenPoint;
        isRedTurn = !isRedTurn;
        soruPaneli.SetActive(false);
        if (isRedTurn)
        {
            zarSira.text = "KIRMIZI İÇİN BİR ZAR ÇEK";
            zarSira.color = Color.red;
        }
        else
        {
            zarSira.text = "YEŞİL İÇİN BİR ZAR ÇEK";
            zarSira.color = Color.green;
        }
        zarPaneli.SetActive(true);
    }
    public IEnumerator buttonB()
    {
        butonDevrede = false;
        tikTak.Stop();
        stopTimer = true;
        if (cvp == 'b')
        {
            butonB.image.color = Color.green;
            correct.Play();
            if (zorluk.text == "Zorluk: ZOR")
            {
                dogru.text = "Doğru Cevap\n+30 Puan";
                if (isRedTurn == true)
                {
                    redPoint += 30;
                    if (ilkTur)
                    {
                        ilkTur = false;
                        yield return new WaitForSeconds(2);
                        isRedTurn = false;
                        player.text = "YEŞİL OYUNCU";
                        player.color = Color.green;
                        soruPaneli.SetActive(false);
                        hazirPaneli.SetActive(true);
                        yield break;
                    }
                }
                else
                {
                    greenPoint += 30;
                }
            }
            else if (zorluk.text == "Zorluk: ORTA")
            {
                dogru.text = "Doğru Cevap\n+20 Puan";
                if (isRedTurn == true)
                {
                    redPoint += 20;
                    if (ilkTur)
                    {
                        ilkTur = false;
                        yield return new WaitForSeconds(2);
                        isRedTurn = false;
                        player.text = "YEŞİL OYUNCU";
                        player.color = Color.green;
                        soruPaneli.SetActive(false);
                        hazirPaneli.SetActive(true);
                        yield break;
                    }
                }
                else
                {
                    greenPoint += 20;
                }
            }
            else
            {
                dogru.text = "Doğru Cevap\n+10 Puan";
                if (isRedTurn == true)
                {
                    redPoint += 10;
                    if (ilkTur)
                    {
                        ilkTur = false;
                        yield return new WaitForSeconds(2);
                        isRedTurn = false;
                        player.text = "YEŞİL OYUNCU";
                        player.color = Color.green;
                        soruPaneli.SetActive(false);
                        hazirPaneli.SetActive(true);
                        yield break;
                    }
                }
                else
                {
                    greenPoint += 10;
                }
            }
        }
        else
        {
            butonB.image.color = Color.red;
            switch (cvp)
            {
                case 'd':
                    butonD.image.color = Color.green;
                    break;
                case 'c':
                    butonC.image.color = Color.green;
                    break;
                case 'a':
                    butonA.image.color = Color.green;
                    break;
                case 'e':
                    butonE.image.color = Color.green;
                    break;
            }
            wrong.Play();
            yanlıs.text = "Yanlış Cevap";
            if (isRedTurn == true)
            {
                if (ilkTur)
                {
                    ilkTur = false;
                    yield return new WaitForSeconds(2);
                    isRedTurn = false;
                    player.text = "YEŞİL OYUNCU";
                    player.color = Color.green;
                    soruPaneli.SetActive(false);
                    hazirPaneli.SetActive(true);
                    yield break;
                }
            }
        }
        yield return new WaitForSeconds(2);
        skor.text = "Kırmızı: " + redPoint + "\nYeşil: " + greenPoint;
        isRedTurn = !isRedTurn;
        soruPaneli.SetActive(false);
        if (isRedTurn)
        {
            zarSira.text = "KIRMIZI İÇİN BİR ZAR ÇEK";
            zarSira.color = Color.red;
        }
        else
        {
            zarSira.text = "YEŞİL İÇİN BİR ZAR ÇEK";
            zarSira.color = Color.green;
        }
        zarPaneli.SetActive(true);
    }
    public IEnumerator buttonC()
    {
        butonDevrede = false;
        tikTak.Stop();
        stopTimer = true;
        if (cvp == 'c')
        {
            butonC.image.color = Color.green;
            correct.Play();
            if (zorluk.text == "Zorluk: ZOR")
            {
                dogru.text = "Doğru Cevap\n+30 Puan";
                if (isRedTurn == true)
                {
                    redPoint += 30;
                    if (ilkTur)
                    {
                        ilkTur = false;
                        yield return new WaitForSeconds(2);
                        isRedTurn = false;
                        player.text = "YEŞİL OYUNCU";
                        player.color = Color.green;
                        soruPaneli.SetActive(false);
                        hazirPaneli.SetActive(true);
                        yield break;
                    }
                }
                else
                {
                    greenPoint += 30;
                }
            }
            else if (zorluk.text == "Zorluk: ORTA")
            {
                dogru.text = "Doğru Cevap\n+20 Puan";
                if (isRedTurn == true)
                {
                    redPoint += 20;
                    if (ilkTur)
                    {
                        ilkTur = false;
                        yield return new WaitForSeconds(2);
                        isRedTurn = false;
                        player.text = "YEŞİL OYUNCU";
                        player.color = Color.green;
                        soruPaneli.SetActive(false);
                        hazirPaneli.SetActive(true);
                        yield break;
                    }
                }
                else
                {
                    greenPoint += 20;
                }
            }
            else
            {
                dogru.text = "Doğru Cevap\n+10 Puan";
                if (isRedTurn == true)
                {
                    redPoint += 10;
                    if (ilkTur)
                    {
                        ilkTur = false;
                        yield return new WaitForSeconds(2);
                        isRedTurn = false;
                        player.text = "YEŞİL OYUNCU";
                        player.color = Color.green;
                        soruPaneli.SetActive(false);
                        hazirPaneli.SetActive(true);
                        yield break;
                    }
                }
                else
                {
                    greenPoint += 10;
                }
            }
        }
        else
        {
            butonC.image.color = Color.red;
            switch (cvp)
            {
                case 'b':
                    butonB.image.color = Color.green;
                    break;
                case 'd':
                    butonD.image.color = Color.green;
                    break;
                case 'a':
                    butonA.image.color = Color.green;
                    break;
                case 'e':
                    butonE.image.color = Color.green;
                    break;
            }
            wrong.Play();
            yanlıs.text = "Yanlış Cevap";
            if (isRedTurn == true)
            {
                if (ilkTur)
                {
                    ilkTur = false;
                    yield return new WaitForSeconds(2);
                    isRedTurn = false;
                    player.text = "YEŞİL OYUNCU";
                    player.color = Color.green;
                    soruPaneli.SetActive(false);
                    hazirPaneli.SetActive(true);
                    yield break;
                }
            }
        }
        yield return new WaitForSeconds(2);
        skor.text = "Kırmızı: " + redPoint + "\nYeşil: " + greenPoint;
        isRedTurn = !isRedTurn;
        soruPaneli.SetActive(false);
        if (isRedTurn)
        {
            zarSira.text = "KIRMIZI İÇİN BİR ZAR ÇEK";
            zarSira.color = Color.red;
        }
        else
        {
            zarSira.text = "YEŞİL İÇİN BİR ZAR ÇEK";
            zarSira.color = Color.green;
        }
        zarPaneli.SetActive(true);
    }
    public IEnumerator buttonD()
    {
        butonDevrede = false;
        tikTak.Stop();
        stopTimer = true;
        if (cvp == 'd')
        {
            butonD.image.color = Color.green;
            correct.Play();
            if (zorluk.text == "Zorluk: ZOR")
            {
                dogru.text = "Doğru Cevap\n+30 Puan";
                if (isRedTurn == true)
                {
                    redPoint += 30;
                    if (ilkTur)
                    {
                        ilkTur = false;
                        yield return new WaitForSeconds(2);
                        isRedTurn = false;
                        player.text = "YEŞİL OYUNCU";
                        player.color = Color.green;
                        soruPaneli.SetActive(false);
                        hazirPaneli.SetActive(true);
                        yield break;
                    }
                }
                else
                {
                    greenPoint += 30;
                }
            }
            else if (zorluk.text == "Zorluk: ORTA")
            {
                dogru.text = "Doğru Cevap\n+20 Puan";
                if (isRedTurn == true)
                {
                    redPoint += 20;
                    if (ilkTur)
                    {
                        ilkTur = false;
                        yield return new WaitForSeconds(2);
                        isRedTurn = false;
                        player.text = "YEŞİL OYUNCU";
                        player.color = Color.green;
                        soruPaneli.SetActive(false);
                        hazirPaneli.SetActive(true);
                        yield break;
                    }
                }
                else
                {
                    greenPoint += 20;
                }
            }
            else
            {
                dogru.text = "Doğru Cevap\n+10 Puan";
                if (isRedTurn == true)
                {
                    redPoint += 10;
                    if (ilkTur)
                    {
                        ilkTur = false;
                        yield return new WaitForSeconds(2);
                        isRedTurn = false;
                        player.text = "YEŞİL OYUNCU";
                        player.color = Color.green;
                        soruPaneli.SetActive(false);
                        hazirPaneli.SetActive(true);
                        yield break;
                    }
                }
                else
                {
                    greenPoint += 10;
                }
            }
        }
        else
        {
            butonD.image.color = Color.red;
            switch (cvp)
            {
                case 'b':
                    butonB.image.color = Color.green;
                    break;
                case 'c':
                    butonC.image.color = Color.green;
                    break;
                case 'a':
                    butonA.image.color = Color.green;
                    break;
                case 'e':
                    butonE.image.color = Color.green;
                    break;
            }
            wrong.Play();
            yanlıs.text = "Yanlış Cevap";
            if (isRedTurn == true)
            {
                if (ilkTur)
                {
                    ilkTur = false;
                    yield return new WaitForSeconds(2);
                    isRedTurn = false;
                    player.text = "YEŞİL OYUNCU";
                    player.color = Color.green;
                    soruPaneli.SetActive(false);
                    hazirPaneli.SetActive(true);
                    yield break;
                }
            }
        }
        yield return new WaitForSeconds(2);
        skor.text = "Kırmızı: " + redPoint + "\nYeşil: " + greenPoint;
        isRedTurn = !isRedTurn;
        soruPaneli.SetActive(false);
        if (isRedTurn)
        {
            zarSira.text = "KIRMIZI İÇİN BİR ZAR ÇEK";
            zarSira.color = Color.red;
        }
        else
        {
            zarSira.text = "YEŞİL İÇİN BİR ZAR ÇEK";
            zarSira.color = Color.green;
        }
        zarPaneli.SetActive(true);
    }
    public IEnumerator buttonE()
    {
        butonDevrede = false;
        tikTak.Stop();
        stopTimer = true;
        if (cvp == 'e')
        {
            butonE.image.color = Color.green;
            correct.Play();
            if (zorluk.text == "Zorluk: ZOR")
            {
                dogru.text = "Doğru Cevap\n+30 Puan";
                if (isRedTurn == true)
                {
                    redPoint += 30;
                    if (ilkTur)
                    {
                        ilkTur = false;
                        yield return new WaitForSeconds(2);
                        isRedTurn = false;
                        player.text = "YEŞİL OYUNCU";
                        player.color = Color.green;
                        soruPaneli.SetActive(false);
                        hazirPaneli.SetActive(true);
                        yield break;
                    }
                }
                else
                {
                    greenPoint += 30;
                }
            }
            else if (zorluk.text == "Zorluk: ORTA")
            {
                dogru.text = "Doğru Cevap\n+20 Puan";
                if (isRedTurn == true)
                {
                    redPoint += 20;
                    if (ilkTur)
                    {
                        ilkTur = false;
                        yield return new WaitForSeconds(2);
                        isRedTurn = false;
                        player.text = "YEŞİL OYUNCU";
                        player.color = Color.green;
                        soruPaneli.SetActive(false);
                        hazirPaneli.SetActive(true);
                        yield break;
                    }
                }
                else
                {
                    greenPoint += 20;
                }
            }
            else
            {
                dogru.text = "Doğru Cevap\n+10 Puan";
                if (isRedTurn == true)
                {
                    redPoint += 10;
                    if (ilkTur)
                    {
                        ilkTur = false;
                        yield return new WaitForSeconds(2);
                        isRedTurn = false;
                        player.text = "YEŞİL OYUNCU";
                        player.color = Color.green;
                        soruPaneli.SetActive(false);
                        hazirPaneli.SetActive(true);
                        yield break;
                    }
                }
                else
                {
                    greenPoint += 10;
                }
            }
        }
        else
        {
            butonE.image.color = Color.red;
            switch (cvp)
            {
                case 'b':
                    butonB.image.color = Color.green;
                    break;
                case 'c':
                    butonC.image.color = Color.green;
                    break;
                case 'd':
                    butonD.image.color = Color.green;
                    break;
                case 'a':
                    butonA.image.color = Color.green;
                    break;
            }
            wrong.Play();
            yanlıs.text = "Yanlış Cevap";
            if (isRedTurn == true)
            {
                if (ilkTur)
                {
                    ilkTur = false;
                    yield return new WaitForSeconds(2);
                    isRedTurn = false;
                    player.text = "YEŞİL OYUNCU";
                    player.color = Color.green;
                    soruPaneli.SetActive(false);
                    hazirPaneli.SetActive(true);
                    yield break;
                }
            }
        }
        yield return new WaitForSeconds(2);
        skor.text = "Kırmızı: " + redPoint + "\nYeşil: " + greenPoint;
        isRedTurn = !isRedTurn;
        soruPaneli.SetActive(false);
        if (isRedTurn)
        {
            zarSira.text = "KIRMIZI İÇİN BİR ZAR ÇEK";
            zarSira.color = Color.red;
        }
        else
        {
            zarSira.text = "YEŞİL İÇİN BİR ZAR ÇEK";
            zarSira.color = Color.green;
        }
        zarPaneli.SetActive(true);
    }
    public void clickZar()
    {
        if (zarAktif)
        {
            StartCoroutine(zar());
        }
    }
    public IEnumerator zar()
    {
        if (zarAktif)
        {
            random = Random.Range(1, 7);
            cekilenSayi.text = random.ToString();
            zarAktif = false;
            if (isRedTurn)
            {
                whereIsRed += random;
            }
            else
            {
                whereIsGreen += random;
            }
            yield return new WaitForSeconds(2);
            cekilenSayi.text = "";
            zarAktif = true;
            besSaniye = true;
            piyonHareketiOn = true;
        }
        zarPaneli.SetActive(false);
    }
    public IEnumerator timer(int zorluk)
    {
        tikTakOn = true;
        if (zorluk == 0)
        {
            for (int i = 30; i >= 0; i--)
            {
                sure.text = "Kalan Süre: " + i;
                if (i < 11)
                {
                    if (tikTakOn)
                    {
                        tikTak.Play();
                        tikTakOn = false;
                    }
                    sure.color = Color.red;
                }
                yield return new WaitForSeconds(1);
                if (stopTimer)
                {
                    yield break;
                }
            }
            switch (cvp)
            {
                case 'b':
                    butonB.image.color = Color.green;
                    break;
                case 'c':
                    butonC.image.color = Color.green;
                    break;
                case 'd':
                    butonD.image.color = Color.green;
                    break;
                case 'a':
                    butonA.image.color = Color.green;
                    break;
                case 'e':
                    butonE.image.color = Color.green;
                    break;
            }
            tikTak.Stop();
            butonDevrede = false;
            yanlıs.text = "Süre Doldu";
            if (isRedTurn == true)
            {
                if (ilkTur)
                {
                    ilkTur = false;
                    yield return new WaitForSeconds(2);
                    isRedTurn = false;
                    soruGetir();
                    yield break;
                }
            }
            yield return new WaitForSeconds(2);
            skor.text = "Kırmızı: " + redPoint + "\nYeşil: " + greenPoint;
            isRedTurn = !isRedTurn;
            soruPaneli.SetActive(false);
            zarPaneli.SetActive(true);
        }
        else if (zorluk == 1)
        {
            for (int i = 45; i >= 0; i--)
            {
                sure.text = "Kalan Süre: " + i;
                if (i < 11)
                {
                    if (tikTakOn)
                    {
                        tikTak.Play();
                        tikTakOn = false;
                    }
                    sure.color = Color.red;
                }
                yield return new WaitForSeconds(1);
                if (stopTimer)
                {
                    yield break;
                }
            }
            switch (cvp)
            {
                case 'b':
                    butonB.image.color = Color.green;
                    break;
                case 'c':
                    butonC.image.color = Color.green;
                    break;
                case 'd':
                    butonD.image.color = Color.green;
                    break;
                case 'a':
                    butonA.image.color = Color.green;
                    break;
                case 'e':
                    butonE.image.color = Color.green;
                    break;
            }
            tikTak.Stop();
            butonDevrede = false;
            yanlıs.text = "Süre Doldu";
            if (isRedTurn == true)
            {
                if (ilkTur)
                {
                    ilkTur = false;
                    yield return new WaitForSeconds(2);
                    isRedTurn = false;
                    soruGetir();
                    yield break;
                }
            }
            yield return new WaitForSeconds(2);
            skor.text = "Kırmızı: " + redPoint + "\nYeşil: " + greenPoint;
            isRedTurn = !isRedTurn;
            soruPaneli.SetActive(false);
            zarPaneli.SetActive(true);
        }
        else if (zorluk == 2)
        {
            for (int i = 60; i >= 0; i--)
            {
                sure.text = "Kalan Süre: " + i;
                if (i < 11)
                {
                    if (tikTakOn)
                    {
                        tikTak.Play();
                        tikTakOn = false;
                    }
                    sure.color = Color.red;
                }
                yield return new WaitForSeconds(1);
                if (stopTimer)
                {
                    yield break;
                }
            }
            switch (cvp)
            {
                case 'b':
                    butonB.image.color = Color.green;
                    break;
                case 'c':
                    butonC.image.color = Color.green;
                    break;
                case 'd':
                    butonD.image.color = Color.green;
                    break;
                case 'a':
                    butonA.image.color = Color.green;
                    break;
                case 'e':
                    butonE.image.color = Color.green;
                    break;
            }
            tikTak.Stop();
            butonDevrede = false;
            yanlıs.text = "Süre Doldu";
            if (isRedTurn == true)
            {
                if (ilkTur)
                {
                    ilkTur = false;
                    yield return new WaitForSeconds(2);
                    isRedTurn = false;
                    soruGetir();
                    yield break;
                }
            }
            yield return new WaitForSeconds(2);
            skor.text = "Kırmızı: " + redPoint + "\nYeşil: " + greenPoint;
            isRedTurn = !isRedTurn;
            soruPaneli.SetActive(false);
            zarPaneli.SetActive(true);
        }
    }
    IEnumerator ikiSaniyeC()
    {
        yield return new WaitForSeconds(2);
        if (isRedTurn)
        {
            if (whereIsRed == 4 || whereIsRed == 8 || whereIsRed == 13 || whereIsRed == 18 || whereIsRed == 23 || whereIsRed == 28
             || whereIsRed == 32 || whereIsRed == 35 || whereIsRed == 40 || whereIsRed == 44 || whereIsRed == 47 || whereIsRed == 53)
            {
                piyonHareketiOn = false;
                player.text = "KIRMIZI OYUNCU";
                player.color = Color.red;
                hazirPaneli.SetActive(true);
            }
            else if (whereIsRed >= 56)
            {
                cam.transform.position = new Vector3(21.69f, -11.36f, -10);
                winner.text = "KIRMIZI KÜTÜPHANEYE ULAŞTI";
                oyunSonuPuanlari.text = "Kırmızı'nın Puanı: " + redPoint + "\nYeşil'in Puanı: " + greenPoint;
                piyonHareketiOn = false;
            }
            else
            {
                isRedTurn = false;
                zarSira.text = "YEŞİL İÇİN BİR ZAR ÇEK";
                zarSira.color = Color.green;
                zarPaneli.SetActive(true);
                piyonHareketiOn = false;
            }
        }
        else
        {
            if (whereIsGreen == 4 || whereIsGreen == 8 || whereIsGreen == 13 || whereIsGreen == 18 || whereIsGreen == 23 || whereIsGreen == 28
             || whereIsGreen == 32 || whereIsGreen == 35 || whereIsGreen == 40 || whereIsGreen == 44 || whereIsGreen == 47 || whereIsGreen == 53)
            {
                piyonHareketiOn = false;
                player.text = "YEŞİL OYUNCU";
                player.color = Color.green;
                hazirPaneli.SetActive(true);
            }
            else if (whereIsGreen >= 56)
            {
                cam.transform.position = new Vector3(21.69f, -11.36f, -10);
                winner.text = "YEŞİL KÜTÜPHANEYE ULAŞTI";
                oyunSonuPuanlari.text = "Kırmızı'nın Puanı: " + redPoint + "\nYeşil'in Puanı: " + greenPoint;
                piyonHareketiOn = false;
            }
            else
            {
                isRedTurn = true;
                zarSira.text = "KIRMIZI İÇİN BİR ZAR ÇEK";
                zarSira.color = Color.red;
                zarPaneli.SetActive(true);
                piyonHareketiOn = false;
            }
        }
    }
    public void piyonHareketi()
    {
        if (isRedTurn)
        {
            switch (whereIsRed)
            {
                case 1:
                    rotating = cpK1.transform.position - red.transform.position;
                    red.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 2:
                    rotating = cpK2.transform.position - red.transform.position;
                    red.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 3:
                    rotating = cpK3.transform.position - red.transform.position;
                    red.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 4:
                    rotating = cpK4.transform.position - red.transform.position;
                    red.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 5:
                    rotating = cpK5.transform.position - red.transform.position;
                    red.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 6:
                    rotating = cpK6.transform.position - red.transform.position;
                    red.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 7:
                    rotating = cpK7.transform.position - red.transform.position;
                    red.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 8:
                    rotating = cpK8.transform.position - red.transform.position;
                    red.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 9:
                    rotating = cpK9.transform.position - red.transform.position;
                    red.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 10:
                    rotating = cpK10.transform.position - red.transform.position;
                    red.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 11:
                    rotating = cpK11.transform.position - red.transform.position;
                    red.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 12:
                    rotating = cpK12.transform.position - red.transform.position;
                    red.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 13:
                    rotating = cpK13.transform.position - red.transform.position;
                    red.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 14:
                    rotating = cpK14.transform.position - red.transform.position;
                    red.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 15:
                    rotating = cpK15.transform.position - red.transform.position;
                    red.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 16:
                    rotating = cpK16.transform.position - red.transform.position;
                    red.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 17:
                    rotating = cpK17.transform.position - red.transform.position;
                    red.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 18:
                    rotating = cpK18.transform.position - red.transform.position;
                    red.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 19:
                    rotating = cpK19.transform.position - red.transform.position;
                    red.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 20:
                    rotating = cpK20.transform.position - red.transform.position;
                    red.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 21:
                    rotating = cpK21.transform.position - red.transform.position;
                    red.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 22:
                    rotating = cpK22.transform.position - red.transform.position;
                    red.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 23:
                    rotating = cpK23.transform.position - red.transform.position;
                    red.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 24:
                    rotating = cpK24.transform.position - red.transform.position;
                    red.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 25:
                    rotating = cpK25.transform.position - red.transform.position;
                    red.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 26:
                    rotating = cpK26.transform.position - red.transform.position;
                    red.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 27:
                    rotating = cpK27.transform.position - red.transform.position;
                    red.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 28:
                    rotating = cpK28.transform.position - red.transform.position;
                    red.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 29:
                    rotating = cpK29.transform.position - red.transform.position;
                    red.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 30:
                    rotating = cpK30.transform.position - red.transform.position;
                    red.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 31:
                    rotating = cpK31.transform.position - red.transform.position;
                    red.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 32:
                    rotating = cpK32.transform.position - red.transform.position;
                    red.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 33:
                    rotating = cpK33.transform.position - red.transform.position;
                    red.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 34:
                    rotating = cpK34.transform.position - red.transform.position;
                    red.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 35:
                    rotating = cpK35.transform.position - red.transform.position;
                    red.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 36:
                    rotating = cpK36.transform.position - red.transform.position;
                    red.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 37:
                    rotating = cpK37.transform.position - red.transform.position;
                    red.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 38:
                    rotating = cpK38.transform.position - red.transform.position;
                    red.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 39:
                    rotating = cpK39.transform.position - red.transform.position;
                    red.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 40:
                    rotating = cpK40.transform.position - red.transform.position;
                    red.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 41:
                    rotating = cpK41.transform.position - red.transform.position;
                    red.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 42:
                    rotating = cpK42.transform.position - red.transform.position;
                    red.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 43:
                    rotating = cpK43.transform.position - red.transform.position;
                    red.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 44:
                    rotating = cpK44.transform.position - red.transform.position;
                    red.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 45:
                    rotating = cpK45.transform.position - red.transform.position;
                    red.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 46:
                    rotating = cpK46.transform.position - red.transform.position;
                    red.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 47:
                    rotating = cpK47.transform.position - red.transform.position;
                    red.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 48:
                    rotating = cpK48.transform.position - red.transform.position;
                    red.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 49:
                    rotating = cpK49.transform.position - red.transform.position;
                    red.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 50:
                    rotating = cpK50.transform.position - red.transform.position;
                    red.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 51:
                    rotating = cpK51.transform.position - red.transform.position;
                    red.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 52:
                    rotating = cpK52.transform.position - red.transform.position;
                    red.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 53:
                    rotating = cpK53.transform.position - red.transform.position;
                    red.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 54:
                    rotating = cpK54.transform.position - red.transform.position;
                    red.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 55:
                    rotating = cpK55.transform.position - red.transform.position;
                    red.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case >= 56:
                    rotating = cpK56.transform.position - red.transform.position;
                    red.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
            }
        }
        else
        {
            switch (whereIsGreen)
            {
                case 1:
                    rotating = cpY1.transform.position - green.transform.position;
                    green.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 2:
                    rotating = cpY2.transform.position - green.transform.position;
                    green.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 3:
                    rotating = cpY3.transform.position - green.transform.position;
                    green.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 4:
                    rotating = cpY4.transform.position - green.transform.position;
                    green.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 5:
                    rotating = cpY5.transform.position - green.transform.position;
                    green.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 6:
                    rotating = cpY6.transform.position - green.transform.position;
                    green.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 7:
                    rotating = cpY7.transform.position - green.transform.position;
                    green.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 8:
                    rotating = cpY8.transform.position - green.transform.position;
                    green.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 9:
                    rotating = cpY9.transform.position - green.transform.position;
                    green.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 10:
                    rotating = cpY10.transform.position - green.transform.position;
                    green.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 11:
                    rotating = cpY11.transform.position - green.transform.position;
                    green.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 12:
                    rotating = cpY12.transform.position - green.transform.position;
                    green.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 13:
                    rotating = cpY13.transform.position - green.transform.position;
                    green.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 14:
                    rotating = cpY14.transform.position - green.transform.position;
                    green.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 15:
                    rotating = cpY15.transform.position - green.transform.position;
                    green.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 16:
                    rotating = cpY16.transform.position - green.transform.position;
                    green.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 17:
                    rotating = cpY17.transform.position - green.transform.position;
                    green.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 18:
                    rotating = cpY18.transform.position - green.transform.position;
                    green.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 19:
                    rotating = cpY19.transform.position - green.transform.position;
                    green.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 20:
                    rotating = cpY20.transform.position - green.transform.position;
                    green.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 21:
                    rotating = cpY21.transform.position - green.transform.position;
                    green.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 22:
                    rotating = cpY22.transform.position - green.transform.position;
                    green.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 23:
                    rotating = cpY23.transform.position - green.transform.position;
                    green.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 24:
                    rotating = cpY24.transform.position - green.transform.position;
                    green.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 25:
                    rotating = cpY25.transform.position - green.transform.position;
                    green.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 26:
                    rotating = cpY26.transform.position - green.transform.position;
                    green.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 27:
                    rotating = cpY27.transform.position - green.transform.position;
                    green.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 28:
                    rotating = cpY28.transform.position - green.transform.position;
                    green.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 29:
                    rotating = cpY29.transform.position - green.transform.position;
                    green.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 30:
                    rotating = cpY30.transform.position - green.transform.position;
                    green.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 31:
                    rotating = cpY31.transform.position - green.transform.position;
                    green.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 32:
                    rotating = cpY32.transform.position - green.transform.position;
                    green.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 33:
                    rotating = cpY33.transform.position - green.transform.position;
                    green.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 34:
                    rotating = cpY34.transform.position - green.transform.position;
                    green.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 35:
                    rotating = cpY35.transform.position - green.transform.position;
                    green.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 36:
                    rotating = cpY36.transform.position - green.transform.position;
                    green.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 37:
                    rotating = cpY37.transform.position - green.transform.position;
                    green.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 38:
                    rotating = cpY38.transform.position - green.transform.position;
                    green.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 39:
                    rotating = cpY39.transform.position - green.transform.position;
                    green.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 40:
                    rotating = cpY40.transform.position - green.transform.position;
                    green.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 41:
                    rotating = cpY41.transform.position - green.transform.position;
                    green.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 42:
                    rotating = cpY42.transform.position - green.transform.position;
                    green.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 43:
                    rotating = cpY43.transform.position - green.transform.position;
                    green.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 44:
                    rotating = cpY44.transform.position - green.transform.position;
                    green.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 45:
                    rotating = cpY45.transform.position - green.transform.position;
                    green.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 46:
                    rotating = cpY46.transform.position - green.transform.position;
                    green.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 47:
                    rotating = cpY47.transform.position - green.transform.position;
                    green.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 48:
                    rotating = cpY48.transform.position - green.transform.position;
                    green.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 49:
                    rotating = cpY49.transform.position - green.transform.position;
                    green.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 50:
                    rotating = cpY50.transform.position - green.transform.position;
                    green.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 51:
                    rotating = cpY51.transform.position - green.transform.position;
                    green.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 52:
                    rotating = cpY52.transform.position - green.transform.position;
                    green.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 53:
                    rotating = cpY53.transform.position - green.transform.position;
                    green.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case 54:
                    rotating = cpY54.transform.position - green.transform.position;
                    green.transform.Translate(rotating * Time.deltaTime);
                    break;
                case 55:
                    rotating = cpY55.transform.position - green.transform.position;
                    green.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
                case >= 56:
                    rotating = cpY56.transform.position - green.transform.position;
                    green.transform.Translate(rotating * Time.deltaTime * 2);
                    break;
            }
        }
    }
    public void tekrarOyna()
    {
        soruPaneli.SetActive(false);
        zarPaneli.SetActive(false);
        dogru.text = "";
        yanlıs.text = "";
        skor.text = "Kırmızı: 0" + "\nYeşil: 0";
        player.text = "KIRMIZI OYUNCU";
        player.color = Color.red;
        cam.transform.position = new Vector3(21.69f, 0, -10);
        greenPoint = 0;
        redPoint = 0;
        whereIsGreen = 0;
        whereIsRed = 0;
        green.transform.position = new Vector3(7.8f, 4.17f, 0);
        red.transform.position = new Vector3(7.57f, 4.17f, 0);
        isRedTurn = true;
        ilkTur = true;
        hazirPaneli.SetActive(true);
        zarSira.text = "KIRMIZI İÇİN BİR ZAR ÇEK";
    }
}