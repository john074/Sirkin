using System.Data;
using System.Runtime.CompilerServices;

namespace Lab5;
class Program
{
    static void Main(string[] args)
    {   
        Backpack();
    }

    static void HanoiTower(int disks, string[] Start, string[] Goal, string[] Helper, bool show){
        if(disks == 0)
            return;

        HanoiTower(disks-1, Start, Helper, Goal, show);
        int IndxSug = Array.IndexOf(Start, ".");
        int indx = IndxSug == -1? Start.Length-1 : IndxSug-1 == -1 ? 0 : IndxSug-1;
        Goal[Array.IndexOf(Goal, ".")] = Start[indx];
        Start[indx] = ".";
        if(show){
            for(int i=Start.Length-1; i>=0; i--)
            {   
                System.Console.WriteLine($"{Start[i]}\t{Helper[i]}\t{Goal[i]}");
            }
            System.Console.WriteLine();
        }
        HanoiTower(disks-1, Helper, Goal, Start, show);
    }

    static void HanoiTower(int disks, bool show){
        string[] FirstRod = new string[disks];
        string[] SecondRod = new string[disks];
        string[] ThirdRod = new string[disks];

        for(int i=1; i<=disks; i++)
        {
            string disk = "";
            for(int j=disks-i+1; j>0; j--)
            {
                disk += "#";
            }
            FirstRod[i-1] = disk;
            SecondRod[i-1] = ".";
            ThirdRod[i-1] = ".";
        }

        System.Console.WriteLine("Before:");
        for(int i=FirstRod.Length-1; i>=0; i--)
        {   
            System.Console.WriteLine($"{FirstRod[i]}\t{SecondRod[i]}\t{ThirdRod[i]}");
        }
        System.Console.WriteLine();

        HanoiTower(FirstRod.Length, FirstRod, ThirdRod, SecondRod, show);

        System.Console.WriteLine("After:");
        for(int i=FirstRod.Length-1; i>=0; i--)
        {   
            System.Console.WriteLine($"{FirstRod[i]}\t{SecondRod[i]}\t{ThirdRod[i]}");
        }
    }

    static string toBinary(int num, string ans="")
    {
        if(num < 2){
            return num%2 + ans;
        }
        return toBinary(num / 2, num%2 + ans);
    }

    static void Equation()
    {   
        System.Console.WriteLine("Введите числа через пробел");
        string[] nums = Console.ReadLine().Split();
        char[] eq = new char[nums.Length*2-1];
        int count = 0;

        for(int i=0; i<eq.Length; i++)
        {
            if(i % 2 == 0){
                eq[i] = Convert.ToChar(nums[count++]);
            }
            else{
                eq[i] = '@';
            }
        }

        for(int i=0; i<eq.Length; i++)
        {
            if(eq[i] == '@')
            {
                char[] eqC = new char[eq.Length];
                for(int j=0; j<eq.Length; j++)
                {
                    eqC[j] = eq[j];
                }
                eqC[i] = '=';
                for(int j=0; j<eq.Length; j++)
                {
                    if(eqC[j] == '@'){
                        eqC[j] = '+';
                    }
                }
                Solve(eqC);
            }
        }
    }

    static void Solve(char[] eq, int indx=0){
        char[] vars = {'+', '-', '*', '/'};
        if(indx == vars.Length-1)
        {   
            return;
        }
        DataTable dt = new DataTable();
        for(int i=0; i<eq.Length; i++)
        {  
            if(vars.Contains(eq[i])){
                eq[i] = vars[indx];
                string expression = "";
                foreach(char j in eq)
                    expression += j;
                if((bool)dt.Compute(expression, ""))
                    System.Console.WriteLine(expression);
                Solve(eq, indx+1);
            }
        }
    }

    static void Backpack()
    {
        int[] values = new int[10];
        int[] weights = new int[10];
        System.Console.WriteLine("Введите цены и веса предметов:");
        for(int i=0; i<10; i++)
        {
            string data = Console.ReadLine();
            values[i] = Convert.ToInt32(data.Split()[0]);
            weights[i] = Convert.ToInt32(data.Split()[1]);
        }

        System.Console.WriteLine($"Ответ: {BackpackRec(values, weights, values.Length-1, 10)}");
        
    }

    static int BackpackRec(int[] values, int[] weights, int item, int capacity)
    {   
        if(capacity < 0){
            return int.MinValue;
        }
        if(item < 0 || capacity == 0)
        {
            return 0;
        }
        int take = values[item] + BackpackRec(values, weights, item-1, capacity-weights[item]);
        int notTake = BackpackRec(values, weights, item-1, capacity);
        return take > notTake ? take : notTake;
    }

    static int Rabbits(int months, int CurRabbits=2, int PrevRabbits=0)
    {
        if(months == 0)
            return PrevRabbits;
        return Rabbits(--months, CurRabbits+PrevRabbits, CurRabbits);
    }

    static int RabbitsDieable(int months, int lifespan)
    {   
        if(lifespan < 2)
        {
            System.Console.WriteLine("Все кролики погибли раньше появления первого потомства");
            return 0;
        }
        int[] generations = new int[lifespan];
        for(int i=0; i<generations.Length; i++)
        {
            generations[i] = 0;
        }
        return RabbitsDieableRec(months, generations);
    }

    static int RabbitsDieableRec(int months, int[] generations, int count=1,int CurRabbits=2, int PrevRabbits=0){
        if(months+1 == count){
            return CurRabbits;
        }
        else if(count == 1)
        {   
            System.Console.WriteLine($"{1}) Родилось: {PrevRabbits} Умерло: {generations[generations.Length-1]} Итого: {CurRabbits + PrevRabbits - generations[generations.Length-1]}");
            return RabbitsDieableRec(months, generations, ++count);
        }
        generations[0] = PrevRabbits;
        ShiftArray(generations);
        System.Console.WriteLine($"{count}) Родилось: {PrevRabbits} Умерло: {generations[generations.Length-1]} Итого: {CurRabbits + PrevRabbits - generations[generations.Length-1]}");
        return RabbitsDieableRec(months, generations, ++count, CurRabbits + PrevRabbits - generations[generations.Length-1], CurRabbits);
    }

    static void ShiftArray(int[] array)
    {
        for(int i=array.Length-2; i>=0; i--)
        {
            array[i+1] = array[i];
        }
        array[0] = 0;
    }

    static bool Palindrom(string text, int indx1, int indx2)
    {
        if(indx1 >= indx2){
            return true;
        }
        if(text[indx1] == text[indx2]){
            return Palindrom(text, ++indx1, --indx2);
        }
        else{
            return false;
        }

    }
}

