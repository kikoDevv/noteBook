using System;
using System.Collections.Generic;

namespace final
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalBloggar = 0; // detta int används för att spara total räckning av inskrivda titlar med hjälp av titelFörBlogg.count.
            int SökIndexÄr = 0; // här sparas resulaten på binärsökning som innefåller index nummer på hittade index. anledningen till att jag inte deklererade det -
            //nära till är att den använder jag på olika radar i mitt kod.
            int select = 0;// här sparas värde på hur många gånger down eller up arrow tryckdes, mer infå på rad 29.
            string sökOrd; // här sparas string värde från användaren och det används ochså på olika rader.
            bool program = true; // det här bolen är för while loop på rad 19 och styrs av användaren på rad 167 efter att användaren väld att avsluta programmet.
            List<string> datum = new List<string>(); // här sparas datum
            List<string> titelFörBlogg = new List<string>();//här använder vi List istället för array för att vi ska slippa gissa slut idex på listan. detta list är för att spara rubrik för blogget.
            List<string> textFörBlogg = new List<string>();// i dethär listan kommer vi spara text för blogget.
            bool sorterat = false;
            while (program)
            {
                bool enterNotPressed = true;
                while (enterNotPressed)
                {
                    menyvall(select);// här har vi en metod för menyvall och i parameter använder vi select, metoden är för att printa rätt alternativ till Console skärm och den känner av vilken alternativ användaren har vald genom select värde.
                    ConsoleKeyInfo pressadeKnapp = Console.ReadKey();
                    // det här kodbloken tog mig 2 dagar att komma på det lösningen
                    // ett if struktur med 4 vilkorer och instruktion.
                    if (pressadeKnapp.Key == ConsoleKey.DownArrow) // vilkor här är att känna av vilken knapp trycks(med hjälp av ConsoleKeyInfo och ReadKey) om det är DownArrow som tryckdes då..
                    {
                        select++; // höjs värde på select med 1.
                        if (select == 5)// om värde i select är mer än antal alternativ som vi har i huvudmenyn då resettas select till 0...
                        {               // eftersom select innehåller värde som vi använder senare båda i switch vilkor men ochså i metoden menyvall(select).
                            select = 0;
                        }

                    }
                    else if (pressadeKnapp.Key == ConsoleKey.UpArrow)

                    {
                        select--; // vi säger till att värdet i select ska inte överstigga mer eller mindre än antal alternativ som vi har i huvud meny och switch case. om det gör det, så resettar vi det till 4 här
                                  // eftersom detta värde ska också användas i metoden menyvall för att kunna printa ut olika alternativ meny, mer info i rad 182.
                        if (select == -1)
                        {
                            select = 4;
                        }

                    }
                    else if (pressadeKnapp.Key == ConsoleKey.Enter)
                    {
                        
                        enterNotPressed = false; // detta boolean deklererades i rad 22 och används för att kunna stänga av while loopen i rad 23 för värje gång_
                        //användaren tryckar Enter key, detta är det ända sättet användaren kan gå ut från while loppen(huvudmeny).
                        
                    }
                    else
                    {
                        kultText("Styr menyn med ner eller up arrow välje med enter!"); // här ropar jag på min metod som printar texten lite snyggare och i parameter, man kan bara skriva textet direck och metoden gör jobbet. jag har förklarat metoden i sin rad.
                        Console.ReadKey();
                        continue;
                    }
                 
                }
                // här anväder vi select värde i switch vilkor som kör olika kodblok i olika case.
                // om användaren har tryck nerknappen 3 gånger och sen Enter som för sig breakar ut användaren från while loopen då select värde är 3 och nästa cod som körs är case 2 eftersom pc räknar alltid från 0,
                switch (select)
                {
                    case 0:// case 0, här frågar vi användaren om infromation och sparar vi den i string listan.
                        Console.Clear();// eftersom anändaren ska skriva så tar vi bort menyn så länge.
                        Console.WriteLine("Skriv titel till din inlägg");
                        titelFörBlogg.Add(Console.ReadLine());// jag skulle kunna tänka mig att använda TryParse om det inte vart string. 
                        datum.Add(DateTime.Now.ToString("f"));// här sparas nuvarande datum från användarens pc efter att den har skrivt rubriken. f i parameter är ett custom time format från microsoft
                        Console.WriteLine("Skriv text till din inlägg");
                        textFörBlogg.Add(Console.ReadLine()); // här sprar vi texten som användaren skriver i textFörBlogg och dem sparas i index order och inte på varandra.
                                                              // att använda 3 lista som sparar rubrik, text och time är väldigt bra för då all information sparas i samma idex fast på olika listro.
                        sorterat = false; // binärsökning fungerar inte om användaren inte sörterar först. värje gång användaren lägger till text eller redigerar tex, sorterat=false för att på minna om sortering sen.
                        break;
                    // case 1, här sorterar rubriks bloggar i alfabetisk order(bubbelsortering). vi använder oss också ToUpper för att printa ut rubriker i stora bokstäver eftersom rubriker ofta bruka vara med stor boktav. men vi converterar inte hela listan till stor bokstav.
                    case 1:
                        Console.Clear(); // tar vi bort all printar från Console skärm.
                        for (int i = 0; i < titelFörBlogg.Count; i++) // här för att vi ska kunna printa ut all rubrik,text och datum i samma ordning för värje index så printer 3 index från 3 olika list samtidigt i rad och då använder vi oss I i index.
                        {
                            Console.WriteLine("----------------[inlägg från " + datum[i] + "]----------------"); // printa första index i datum lista
                            Console.WriteLine(titelFörBlogg[i].ToUpper());// printa första index i titelFörBlogg med stor bokstav.
                            Console.WriteLine(textFörBlogg[i]); // printa första index i textFörBlogg, och nu förseter loopen lika många gånger som titelFörBloggs längd och värje gång lägg till 1 i I värde vilket gör att nästa gån prints andra index osv.
                        }
                        totalBloggar = titelFörBlogg.Count;//här räcknar vi listans längd som motsvarar den totala bloggar.
                        Console.WriteLine("--------------[Du har " + totalBloggar + " titlar som sorteras nu.. ]--------------");// här printar vi det till användaren för tydlighets skull.
                        //här kör vi en bubbelsörtering, och vi jämför det första index med andra och om index 0 är storre än index 1, vi byter plats och går vidare med nästa tills en kvar. och sen gör vi samma prosse men i andra if loopen.
                        for (int i = 0; i < titelFörBlogg.Count - 1; i++) // här använder vi -1 för att i slut index måste vara två index som man ska kunna gämföra annar det blir out of range error.
                        {
                            for (int j = 0; j < titelFörBlogg.Count - i - 1; j++)
                            {
                                int result = titelFörBlogg[j].CompareTo(titelFörBlogg[j + 1]); // här gäller .CompareTo istället för >,=,< eftersom det är string och inte int.
                                                                                               // då får vi antingern 0 om det är lika stor som  den andra -1 om det är mindre och 1 om det är storre.
                                                                                               // nu när vi har fått resultaten i int så kan vi direkt gämföra med =,>,<.
                                if (result == 1)
                                {
                                    string temp = titelFörBlogg[j]; // string temp är för att när vi försöker byta index med vandra så behäver vi först spara värdet på en index nonstans för att den ska inte försvinna.
                                    titelFörBlogg[j] = titelFörBlogg[j + 1];
                                    titelFörBlogg[j + 1] = temp;

                                }
                            }
                        }

                        countDown(13);// här ropar jag på min kult countdwon och i parameter anger jag hur många gånger loopen ska uprepas, på så sätt kan man styra längden på printline.
                        Console.WriteLine("");// visual.
                        Console.WriteLine("+----------------------------------------------------------------------------+\n|                               Sörterat                                     |\n+----------------------------------------------------------------------------+");
                        sorterat = true;
                        for (int i = 0; i < titelFörBlogg.Count; i++)
                        {
                            Console.WriteLine("----------------[inlägg från " + datum[i] + "]----------------"); // samma process här som på rad 81.
                            Console.WriteLine(titelFörBlogg[i].ToUpper());
                            Console.WriteLine(textFörBlogg[i]);
                        }
                        Console.ReadKey();
                        break;

                    case 2: //case 2 handlar om att binärsökning och redigering av hittade index.
                        Console.Clear();
                        if (sorterat == true)
                        {
                            Console.WriteLine("Sök bland dina titlar för att redigera");
                            sökOrd = Console.ReadLine(); // sökordet sparas här den använder vi sen när vi gör vår binärsökning.
                            if (BnärSök(titelFörBlogg, 0, titelFörBlogg.Count, sökOrd) != -1) // jag har skrivit förklarningen om metoden i rad 192.
                            {

                                Console.WriteLine("Sökordet " + sökOrd + " hittades i bland dina titar i index " + BnärSök(titelFörBlogg, 0, titelFörBlogg.Count, sökOrd)); // man kunde ju även tänka såhär. int indexÄr=BnärSök(titelFörBlogg, 0, titelFörBlogg.Count, sökOrd));
                                SökIndexÄr = BnärSök(titelFörBlogg, 0, titelFörBlogg.Count, sökOrd); // den sparar hittade index numret. 
                                Console.WriteLine("Hella textet i index " + SökIndexÄr + " är " + titelFörBlogg[SökIndexÄr]); //nu när vi har hittat index numret så vi ba printa ut det.
                                Console.WriteLine("vad vill du ändra texten " + titelFörBlogg[SökIndexÄr] + " till?"); // här frågar vi användaren om ny text som ska ersättas med den texet som vi precis fick reda indexet på.
                                string ErsättningsText = Console.ReadLine();// har sparar vi textet och sen ersätter vi i nästa stegg, man kan ersätta den direkt utan att spara ocksä men ja vill spara det för att vara säker. ex index=ReadLine();
                                titelFörBlogg[SökIndexÄr] = ErsättningsText;
                                Console.WriteLine("Nu har du ändrat ditt titel till " + titelFörBlogg[SökIndexÄr]);
                                sorterat = false;// updaterar vi sortering processen med false eftersom användaren har precis ändrat ruriken och för att användaren ska kunn söka igen behöver den sörteras på nytt.
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(sökOrd + " finns inte med bland dina titlar"); // om metoden returnerar -1 då det betyder att sökordet inte hittades.
                                Console.ReadKey();
                                Console.ResetColor();
                            }
                        } else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("rubrik måste sorteras först!");
                            Console.ReadKey();
                            Console.ResetColor();
                        }
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("------------------------[Här har du alla dina bloggar]--------------------------");
                        for (int i=0; i<titelFörBlogg.Count; i++)
                        {
                            Console.WriteLine("----------------[inlägg från " + datum[i] + "]----------------"); // här rupar jag på min datum lista som var sparat efter användaren skrivit sin inlägg titel.
                            Console.WriteLine(titelFörBlogg[i].ToUpper());      /// här använder jag to upper för att printa alla titel indexar i
                            Console.WriteLine(textFörBlogg[i]);                  // stora bokstäver eftersom titel brukar vara stor bokstav .
                            totalBloggar = titelFörBlogg.Count; //detta är för att räckna ut hur många titlar användaren har skrivit och eftersom titlar och text är lika många så skipper vi räcka total text.
                            Console.WriteLine("-------------------------[Du hade totalt "+totalBloggar+" bloggar ]----------------------------");
                        }
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.WriteLine("Programmet avsluts!");
                        countDown(5); // här kallar jag på metoden countDown och anger 7 i parameter som för sig är 7:an som paseras till fro parameter för att kunna bestäma lägd på for loop
                        program = false;
                        break;
                }

                
                
                
            }
        
        }
         // här är en metod som tar emot string och printar varje index i string i samma rad och det är 100msec delay för värje index den printar.
        static void kultText(string ReadLineHär/*här tar motoden emot string värdet*/)
        {
            for (int i=0; i<ReadLineHär.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow; // färjbytte.
                Console.Write(ReadLineHär[i]); // här istället för att printa ut i värje Linje så printar vi ut all indexar i samma rad med hjälp av Console.Write
                System.Threading.Thread.Sleep(100);
            }
            
            
        }
        // BinärSökning av string
        // hur bynärsökning fungerar, först sörterar vi listan sen gämför vi värdet i mitten av array med sökordet om värdet var mindre an sökordet då det betyder att värdet måste vara
        // nonstans i vänster sidan av listan eftersom vi har sörterat listan, det kan inte vara möjligt att den ligger i höger sidan av listan. då ignorerar vi helften av listan som ligger i höger och
        // försätter vi samma process genom att anropa metoden i kodblocken om och om tills right(arra.lenght) är mindre än 0). det som är bra med binärsökning gämför med linjar är att det är mycket snabbar om det finns sort mangd av data än att gämföra värdet med var och en i listan.
        // vi behöver ange information om listans längd och sökordet i metodens parameter.
        static int BnärSök(/* data typ*/List<string> listan,/*längd, från*/ int left, /*längd till*/int right, /*sökordet*/string sök)
        {
            if (left <= right) // det här loopen ska försätta tills right(arra.lenght) är mindre än left(0) för att den kan ropa metoden om och om i kodbloken.
            {
                int middle = (left + right) / 2; // här fixar vi en middle värde som är längden av array delat i 2.
                if (listan[middle].StartsWith(sök))// här kollar vi om mitt värde är lika med sökordet vilket ofta bruka inte vara det. .StartWith funkar bättre än compareTo här. eftersom man mehöver inte skriva hella ordet.
                {
                    return middle; // om det var så då retunerar vi index numret som ligger i mitten.
                }
                if (listan[middle].CompareTo(sök) ==1) // här bestämms vilken sida av array ska ignoreras. om middle värde är större an sökvärde då vet vi att sökvärdet ligger nonstans i vänstra sidan av array
                                                       // då kallar vi på metoden igen och denhär gången ignorerar vi högersidan, hur går vi det, istället för att skriva hela längden av arra i metodens parameter
                                                       // vi skriver bara hälften då blir det 0, och middlevärde som är isåfall längden av array delat i två -1 för att dator räcknar från 0.
                                                       // här använder vi .CompareTo eftersom det är string som vi jobbar med och den returnerar alltid 0 om det är lika stor, -1 om det är mindre, 1 om det är storre.
                {
                    return BnärSök(listan, left, middle - 1, sök);

                }
                else
                {
                    return BnärSök(listan, middle + 1, right, sök); // samma process här om middelvärde var mindre än sökvärde.
                }
            }// om right blev mindre än left då returnerar vi -1 då vet vi att sökordet finns inte med i listan.
            else
            {
                return -1;
            }
        
        }
        // en fancy countdown metod här för att printa snyggt stecka med olika färje.
        static void countDown(int längd)
        {
            string temp = "-";
            for (int i = 0; i < längd; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(temp[0]);
                System.Threading.Thread.Sleep(200);
            }
            for (int i = 0; i < längd; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write(temp[0]);
                System.Threading.Thread.Sleep(200);
            }
            for (int i = 0; i < längd; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write(temp[0]);
                System.Threading.Thread.Sleep(200);
            }
            for (int i = 0; i < längd; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write(temp[0]);
                System.Threading.Thread.Sleep(200);
            }
            for (int i = 0; i < längd; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(temp[0]);
                System.Threading.Thread.Sleep(200);
            }

        }

        // metoden här tär hand om visual sidan av huvudmenyn med hjälp av select värde i parameter.
        // här kunde man lika gärna använda swich men jag föredrar alltid if.
        // select värdet bestämmer över vilka kodblok i if statement ska man köra.
        static void menyvall(int selectedIndex)
        {
            Console.Clear();
            string[] menyy = new string[] { "+---------------------------+\n|  Skriv blogg              |", "|  Sörtera dina rubriker    |", "|  Sök/redigera din blogg   |", "|  Printa ut all bloggar    |", "|  Avsluta programmet       |\n+---------------------------+"};
            string[] array = new string[] { " -> Skriv blogg             |", " -> Sörtera dina rubriker   |", " -> Sök/redigera din blogg  |", " -> Printa ut all bloggar   |", " -> Avsluta programmet      |" };
            if (selectedIndex == 0)
            {
                Console.WriteLine("+---------------------------+");
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(array[selectedIndex]);
                Console.ResetColor();
                Console.WriteLine(menyy[1]);
                Console.WriteLine(menyy[2]);
                Console.WriteLine(menyy[3]);
                Console.WriteLine(menyy[4]);


            }
            else if (selectedIndex == 1)
            {

                //värdet i select bestäms av rörelse i down eller up arrow key på användarens keyboard, select värdet säger till vilket alternativ i huvudmenyn användaren är i,
                //till ex. om användaren har tryckt 2 gånger på ner knappen och värje gång select värdet ökte med 1 då select värde är 1 och då printas ut denhär kodbloket till console.
                //detta innehåller samma kompia av all huvudmeny alterativ plus att alternativ 1 nu här en indekator och extra färge som görs att användaren vet det den är på alternativ 1.
                Console.WriteLine(menyy[0]);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(array[selectedIndex]);
                Console.ResetColor();
                Console.WriteLine(menyy[2]);
                Console.WriteLine(menyy[3]);
                Console.WriteLine(menyy[4]);

            }
            else if (selectedIndex == 2)
            {

                Console.WriteLine(menyy[0]);
                Console.WriteLine(menyy[1]);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(array[selectedIndex]);
                Console.ResetColor();
                Console.WriteLine(menyy[3]);
                Console.WriteLine(menyy[4]);

            }
            else if (selectedIndex == 3)
            {

                Console.WriteLine(menyy[0]);
                Console.WriteLine(menyy[1]);
                Console.WriteLine(menyy[2]);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(array[selectedIndex]);
                Console.ResetColor();
                Console.WriteLine(menyy[4]);

            }
            else if (selectedIndex == 4)
            {

                Console.WriteLine(menyy[0]);
                Console.WriteLine(menyy[1]);
                Console.WriteLine(menyy[2]);
                Console.WriteLine(menyy[3]);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(array[selectedIndex]);
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("+---------------------------+");
                Console.ResetColor();

            }
            
        }
    }
}