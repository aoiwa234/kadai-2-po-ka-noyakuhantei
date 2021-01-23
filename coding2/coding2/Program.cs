using System;
using System.Xml.Schema;

namespace coding2
{
    class Program
    {
        static void Main(string[] args)
        {
            //1枚目のカード　0=sudo=記号　1=nunb=数字
            var Card1 = Console.ReadLine();
            string[] card1 = Card1.Split(' ');
            //nt sudo1 = int.Parse(card1[0]);
            int nunb1 = int.Parse(card1[1]);

            //2枚目のカード
            var Card2 = Console.ReadLine();
            string[] card2 = Card2.Split(' ');
            //int sudo2 = int.Parse(card2[0]);
            int nunb2 = int.Parse(card2[1]);

            //3枚目のカード
            var Card3 = Console.ReadLine();
            string[] card3 = Card3.Split(' ');
            //int sudo3 = int.Parse(card3[0]);
            int nunb3 = int.Parse(card3[1]);

            //4枚目のカード
            var Card4 = Console.ReadLine();
            string[] card4 = Card4.Split(' ');
            //int sudo4 = int.Parse(card4[0]);
            int nunb4 = int.Parse(card4[1]);

            //5枚目のカード
            var Card5 = Console.ReadLine();
            string[] card5 = Card4.Split(' ');
            //int sudo5 = int.Parse(card5[0]);
            int nunb5 = int.Parse(card5[1]);

            //数字を入れる配列
            int[] aaa = new int[13];
            //該当する数字に＋１
            aaa[nunb1 - 1] += 1;
            aaa[nunb2 - 1] += 1;
            aaa[nunb3 - 1] += 1;
            aaa[nunb4 - 1] += 1;
            aaa[nunb5 - 1] += 1;

            //上から解答　2枚組カウント　3枚組カウント　連続カウント
            string ans = "er";
            int twocn = 0;
            int thrcn = 0;
            int stcn = 0;

            //ワンペア
            for (int a = 0; a <= 12; a++)
            {
                if(aaa[a] == 2)
                {
                    ans = "ワンペア";
                }
            }
            //ツーペア
            for (int a = 0; a <= 12; a++)
            {
                if (aaa[a] == 2)
                {
                    twocn += 1;
                }
                if(twocn == 2)
                {
                    ans = "ツーペア";
                }
            }
            //スリーカード
            for (int a = 0; a <= 12; a++)
            {
                if (aaa[a] == 3)
                {
                    thrcn = 1;
                }
                if(thrcn == 1)
                {
                    ans = "スリーカード";
                }

            }
            //ストレート
            for (int a = 0; a <= 12; a++)
            {
                if (aaa[a] == 1)
                {
                    //1だと+１していく
                    stcn += 1;
                    //5になったらストレート
                    if(stcn == 5)
                    {
                        ans = "ストレート";
                    }
                }else
                {
                    //途中に0がくるとリセット、2以上がきてもストレートはあり得ないからリセット
                    stcn = 0;
                }
                //連続の途中にKを挟んだ場合 例 Q K A 2 3
                if (aaa[0] == 1 && aaa[9] == 1 && aaa[10] == 1 && aaa[11] == 1 && aaa[12] == 1)
                {
                    ans = "ストレート";
                }
                if (aaa[0] == 1 && aaa[2] == 1 && aaa[10] == 1 && aaa[11] == 1 && aaa[12] == 1)
                {
                    ans = "ストレート";
                }
                if (aaa[0] == 1 && aaa[1] == 1 && aaa[2] == 1 && aaa[11] == 1 && aaa[12] == 1)
                {
                    ans = "ストレート";
                }
                if (aaa[0] == 1 && aaa[1] == 1 && aaa[2] == 1 && aaa[3] == 1 && aaa[12] == 1)
                {
                    ans = "ストレート";
                }
            }
        
            //フラッシュ
            if(card1[0] == card2[0] && card1[0] == card3[0] && card1[0] == card4[0] && card1[0] == card5[0])
            {
                ans = "フラッシュ";
            }
            //フルハウス カウントに使った変数を再利用
            if(twocn == 1 && thrcn == 1)
            {
                ans = "フルハウス";
            }
            //フォーカード
            for (int a = 0; a <= 12; a++)
            {
                if (aaa[a] == 4)
                {
                    ans = "フォーカード";
                }
            }
            //ストレートフラッシュ
            if (card1[0] == card2[0] && card1[0] == card3[0] && card1[0] == card4[0] && card1[0] == card5[0])
            {
                for (int a = 0; a <= 12; a++)
                {
                    if (aaa[a] == 1)
                    {
                        //1だと+１していく
                        stcn += 1;
                        //5になったらストレート
                        if (stcn == 5)
                        {
                            ans = "ストレートフラッシュ";
                        }
                    }
                    else
                    {
                        //途中に0がくるとリセット、2以上がきてもストレートはあり得ないからリセット
                        stcn = 0;
                    }
                }
                //連続の途中にKを挟んだ場合 例 Q K A 2 3
                if(aaa[0] == 1 && aaa[9] == 1 && aaa[10] == 1 && aaa[11] == 1 && aaa[12] == 1)
                {
                    ans = "ストレートフラッシュ";
                }
                if (aaa[0] == 1 && aaa[2] == 1 && aaa[10] == 1 && aaa[11] == 1 && aaa[12] == 1)
                {
                    ans = "ストレートフラッシュ";
                }
                if (aaa[0] == 1 && aaa[1] == 1 && aaa[2] == 1 && aaa[11] == 1 && aaa[12] == 1)
                {
                    ans = "ストレートフラッシュ";
                }
                if (aaa[0] == 1 && aaa[1] == 1 && aaa[2] == 1 && aaa[3] == 1 && aaa[12] == 1)
                {
                    ans = "ストレートフラッシュ";
                }
            }

            //ロイヤルフラッシュ
            if (aaa[9] >= 1 && aaa[10] >= 1 && aaa[11] >= 1 && aaa[12] >= 1)
            {
                if(card1[0] == card2[0] && card1[0] == card3[0] && card1[0] == card4[0] && card1[0] == card5[0])
                {
                    ans = "loyalflash";
                }
            }


            //記号出力用
            string sudo1 = "er";
            string sudo2 = "er";
            string sudo3 = "er";
            string sudo4 = "er";
            string sudo5 = "er";


            //記号を判別、出力用sudoに代入
            if (card1[0] == "0")
            {
                sudo1 = "S";
            }
            else if (card1[0] == "1")
            {
                sudo1 = "C";
            }
            else if (card1[0] == "2")
            {
                sudo1 = "D";
            }
            else if (card1[0] == "3")
            {
                sudo1 = "H";
            }

            if (card2[0] == "0")
            {
                sudo2 = "S";
            }
            else if (card2[0] == "1")
            {
                sudo2 = "C";
            }
            else if (card2[0] == "2")
            {
                sudo2 = "D";
            }
            else if (card2[0] == "3")
            {
                sudo2 = "H";
            }

            if (card3[0] == "0")
            {
                sudo3 = "S";
            }
            else if (card3[0] == "1")
            {
                sudo3 = "C";
            }
            else if (card3[0] == "2")
            {
                sudo3 = "D";
            }
            else if (card3[0] == "3")
            {
                sudo3 = "H";
            }

            if (card4[0] == "0")
            {
                sudo4 = "S";
            }
            else if (card4[0] == "1")
            {
                sudo4 = "C";
            }
            else if (card4[0] == "2")
            {
                sudo4 = "D";
            }
            else if (card4[0] == "3")
            {
                sudo4 = "H";
            }

            if (card5[0] == "0")
            {
                sudo5 = "S";
            }
            else if(card5[0] == "1")
            {
                sudo5 = "C";
            }
            else if (card5[0] == "2")
            {
                sudo5 = "D";
            }
            else if (card5[0] == "3")
            {
                sudo5 = "H";
            }

            if (nunb1 == 1)
            {
                card1[1] = "A";
            }
            else if (nunb1 == 11)
            {
                card1[1] = "J";
            }
            else if (nunb1 == 12)
            {
                card1[1] = "Q";
            }
            else if (nunb1 == 13)
            {
                card1[1] = "K";
            }

            if (nunb2 == 1)
            {
                card2[1] = "A";
            }
            else if (nunb2 == 11)
            {
                card2[1] = "J";
            }
            else if (nunb2 == 12)
            {
                card2[1] = "Q";
            }
            else if (nunb2 == 13)
            {
                card2[1] = "K";
            }

            if (nunb3 == 1)
            {
                card3[1] = "A";
            }
            else if (nunb3 == 11)
            {
                card3[1] = "J";
            }
            else if (nunb3 == 12)
            {
                card3[1] = "Q";
            }
            else if (nunb3 == 13)
            {
                card3[1] = "K";
            }

            if (nunb4 == 1)
            {
                card4[1] = "A";
            }
            else if (nunb4 == 11)
            {
                card4[1] = "J";
            }
            else if (nunb4 == 12)
            {
                card4[1] = "Q";
            }
            else if (nunb4 == 13)
            {
                card4[1] = "K";
            }

            if (nunb5 == 1)
            {
                card5[1] = "A";
            }
            else if (nunb5 == 11)
            {
                card5[1] = "J";
            }
            else if (nunb5 == 12)
            {
                card5[1] = "Q";
            }
            else if (nunb5 == 13)
            {
                card5[1] = "K";
            }

            //出力
            Console.WriteLine(sudo1 + card1[1] + " " + sudo2 + card2[1] + " " + sudo3 + card3[1] + " " + sudo4 + card4[1] + " " + sudo5 + card5[1]);
            Console.WriteLine(ans);
        }
    }
}
