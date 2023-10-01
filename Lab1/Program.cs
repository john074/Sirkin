using System.Security.AccessControl;

namespace Lab1;
class Program
{
    static void Main(string[] args)
        {   
            Console.WriteLine("Ready");
            task5();
        }

        static void task1()
        {
            int num = Convert.ToInt32(Console.ReadLine());
            int count = 0;
            while(num > 0)
            {
                if(num % 2 == 1) 
                {
                    count++;
                }
                num /= 2;
            }
            Console.WriteLine(count);
        }
        static void task2Strings()
        {
            string num = Console.ReadLine();
            string revNum = string.Empty;
            for(int i=num.Length-1; i>=0; i--)
            {
                revNum += num[i];
            }
            Console.WriteLine(revNum == num);
        }

        static void task2()
        {
            int num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine( (num%10 == (num/1000)%10) && ((num/10)%10 == (num/100)%10) );
        }

        static void task3String()
        {
            string ticketNum = Console.ReadLine();
            int firstPart = 0;
            int secondPart = 0;
            for(int i = 0; i<6; i++)
            {
                if(i < 3)
                {
                    firstPart += (int)ticketNum[i];
                }
                else
                {
                    secondPart += (int)ticketNum[i];
                }
            }

            if(firstPart == secondPart)
            {
                Console.WriteLine(ticketNum);
            }
        }

        static void task3()
        {
            for(int i=0, n1=0, n2=0, n3=0, n4=0, n5=0, n6=0; i<1000000; i++, n6++)
            {
                if(n6 > 9){
                    n5++;
                    n6=0;
                }
                if(n5 > 9){
                    n4++;
                    n5=0;
                }
                if(n4 > 9){
                    n3++;
                    n4=0;
                }
                if(n3 > 9){
                    n2++;
                    n3=0;
                }
                if(n2 > 9){
                    n1++;
                    n2=0;
                }

                if(n1 + n2 + n3 == n4 + n5 + n6){
                    Console.WriteLine($"{n1}{n2}{n3}{n4}{n5}{n6}");
                }
            }
        }

        static void task4()
        {
            string numA = Console.ReadLine();
            string numB = Console.ReadLine();
            string answer = string.Empty;
            int overflow = 0;

            while(numA.Length != numB.Length) 
            {
                if(numA.Length > numB.Length)
                {
                    numB = "0" + numB;
                }
                else if(numB.Length > numA.Length)
                {
                    numA = "0" + numA;
                }
            }

            for(int i=numA.Length-1; i>=0; i--)
            {
                string localSum = (int.Parse(numA[i].ToString()) + int.Parse(numB[i].ToString()) + overflow).ToString();
                if(localSum.Length > 1)
                {
                    overflow = int.Parse(localSum[0].ToString());
                }
                else
                {
                    overflow = 0;
                }
                answer = localSum[^1].ToString() + answer;
            }
            if(overflow != 0)
            {
                Console.WriteLine(overflow.ToString() + answer);
            }
            else
            {
                Console.WriteLine(answer);
            }
        }

        static void task5()
        {
            string letters = "abcdefgh";
            string pos = Console.ReadLine();
            int y = int.Parse(pos[1].ToString());
            int x = 0;
            int[,] combs = new int[,]{{2, 1}, {2, -1}, {-2, 1}, {-2, -1}, {1, 2}, {1, -2}, {-1, -2}, {-1, 2}};

            for(int i = 0; i<letters.Length; i++)
            {
                if (letters[i] == pos[0])
                {
                    x = i;
                    break;
                }
            }

            for(int i=0; i<8; i++)
            {
                if((y + combs[i, 1] > 0 && y+combs[i, 1] < 8) && (x + combs[i, 0] > 0 && x + combs[i, 0] < 8)){
                    Console.WriteLine(letters[x + combs[i, 0]].ToString() + (y + combs[i, 1]));
                }
            }

        }
    }



