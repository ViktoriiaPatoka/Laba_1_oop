using System.Data;

namespace Laba_1_oop
{
    class RecList
    {
        public int data;
        public RecList next;

        public RecList(int i, RecList n)
        {
            data = i;
            next = n;
        }

        public RecList(int i) // конструктор для одного елемента
        {
            data = i;
            next = null;
        }

        public RecList(RecList element) // конструктор для повного рекурсивного копіювання
        {
            if (element == null)
            {
                throw new ArgumentException("Неможливо скопіювати порожній елемент");
            }

            data = element.data;

            if (element.next == null)
            {
                next = null;
            }
            else
            {
                next = new RecList(element.next);
            }
        }

        public static RecList Push(RecList list, int i) // нерекурсивний метод додавання нового елемента
        {
            if (list == null)
            {
                return new RecList(i);
            }
            RecList newNode = new RecList(i);
            RecList current = list;

            while (current.next != null)
            {
                current = current.next;
            }

            current.next = newNode;
            return list;
        }

        public void PushN(int i, int n) // метод додавання нового елемента після n-го
        {
            if (n < 0)
            {
                throw new ArgumentException("Індекс не може бути від'ємним");
            }

            int count = 0;
            RecList current = this;

            while ((current.next != null) && (count < n))
            {
                current = current.next;
                count++;
            }

            if (count < n)
            {
                throw new ArgumentException("Індекс n перевищує довжину списку");
            }

            RecList newNode = new RecList(i);
            newNode.next = current.next;
            current.next = newNode;
        }

        public RecList Pop() // видалення останього елемента
        {
            if (this.next == null)
            {
                return null;
            }

            if (this.next.next == null)
            {
                this.next = null;
                return this;
            }
            this.next = this.next.Pop();
            return this;
        }

        public RecList PopAllN(int x) // видалення елемента з даними х
        {
            if (this.data == x)
            {
                if (this.next == null)
                {
                    return null;
                }

                return this.next.PopAllN(x);
            }

            if (this.next != null)
            {
                this.next = this.next.PopAllN(x);
            }

            return this;
        }

        public static void Print(RecList list) // метод для виводу
        {
            if (list == null)
            {
                Console.WriteLine("Список порожній");
                return;
            }

            RecList current = list;
            while (current != null)
            {
                Console.Write(current.data + " ");
                current = current.next;
            }
            Console.WriteLine();
        }

        public RecList Find(int x) // пошук елемента з заданим значенням
        {
            if (this.data == x)
            {
                return this;
            }

            if (this.next == null)
            {
                return null;
            }

            return this.next.Find(x);
        }

        public int this[int i, int j] // індексатор, що дозволяє знайти мінімальне серед значень
        {
            get
            {
                if (i < 0)
                {
                    i = 0;
                }
                if (j < 0)
                {
                    j = 0;
                }

                int value1 = 0;
                int value2 = 0;

                RecList current1 = this;

                for (int k = 0; k < i; k++)
                {
                    if (current1.next == null)
                    {
                        throw new ArgumentException("Індекс i знаходиться поза межами списку");
                    }
                    current1 = current1.next;
                }

                value1 = current1.data;

                RecList current2 = this;

                for (int d = 0; d < j; d++)
                {
                    if (current2.next == null)
                    {
                        throw new ArgumentException("Індекс j знаходиться поза межами списку");
                    }
                    current2 = current2.next;
                }

                value2 = current2.data;

                if (value1 > value2)
                {
                    return value2;
                }
                if (value1 == value2)
                {
                    return value1;
                }
                else
                {
                    return value1;
                }
            }
        }

        public static explicit operator string(RecList list) // перетворення списку на рядок
        {
            if (list == null)
            {
                return null;
            }

            RecList current = list;

            string str = "";

            while (current != null)
            {
                str += current.data + " ";
                current = current.next;
            }

            return str;
        }

        public static RecList operator +(RecList list1, RecList list2) // перевикористання оператора + на з'єднання двох списків у один
        {
            if (list1 == null && list2 == null)
            {
                return null;
            }
            if (list1 == null)
            {
                return new RecList(list2);
            }
            if (list2 == null)
            {
                return new RecList(list1);
            }

            RecList newList = new RecList(list1);
            RecList current = newList;

            while (current.next != null)
            {
                current = current.next;
            }

            current.next = new RecList(list2);

            return newList;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            RecList a = new RecList(20, new RecList(20, new RecList(20, new RecList(20, new RecList(20)))));
            RecList.Print(a);
            a = a.PopAllN(20);
            RecList.Print(a);
            a = RecList.Push(a, 50);
            RecList.Print(a);
        }
    }
}