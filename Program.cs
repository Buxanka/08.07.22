using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;

namespace _08._07._22_2_
{
    class ipADDR
    {
        private static readonly int[] _ip = new int[4] { 0, 0, 0, 0 };
        public int[] ip = _ip;
        public string Print()
        {
            string res = this.ip[0] + "."
                + this.ip[1] + "."
                + this.ip[2] + "."
                + this.ip[3];
            return res;
        }
        public void Input()
        {
            for (int i = 0; i <= 3; i++)
            {
                this.ip[i] = AsignOktet(i);
            }
        }
        public int AsignOktet(int _index)
        {
            bool _correct = false;
            var oktet = 0;
            do
            {
                try
                {
                    oktet = int.Parse(Console.ReadLine());
                    _correct = true;
                }
                catch
                {
                    Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                }
            } while (!_correct);
            return oktet;
        }
        class email
        {
            public string _username;
            public char _delimiter = '@';
            public string _domainName;
            public email()
            {
                _username = "user";
                _domainName = "mail.ru";
            }
            public bool isCorect(string _addres)
            {
                bool res;
                //string _addres = _username + _delimiter + _domainName;
                Regex _regex = new Regex(@"(\w+@\w+\.\w+)");
                MatchCollection _matchCollection = _regex.Matches(_addres);
                if (_matchCollection.Count > 0)
                {
                    res = true;
                }
                else
                {
                    res = false;
                }
                return res;
            }
            public bool setPost(string _elAddres)
            {
                bool res = true;
                int _index = 0;
                if (isCorect(_elAddres))
                {
                    this._username = "";
                    this._domainName = "";
                    for (int i = 0; i < _elAddres.Length; i++)
                    {
                        if (_elAddres[i] == '@')
                        {
                            _index = i;
                        }
                    }
                    this._username = _elAddres.Substring(0, _index);
                    this._domainName = _elAddres.Substring(_index + 1);
                    res = true;
                }
                else
                {
                    res = false;
                }
                return res;
            }
            public string getPost()
            {
                string res = this._username
                    + this._delimiter
                    + this._domainName;
                return res;
            }
        }
        class dateTime
        {
            public int _year = 2022;
            public int _mounth = 1;
            public int _day = 1;
            public bool Day(int day)
            {
                bool res = true;
                if (_day >= 31 && _day <= 1)
                {
                    Console.WriteLine("Некорректный ввод!");
                    res = false;
                }
                return res;
            }
            public bool Mounth(int mounth)
            {
                bool res = true;
                if (_mounth >= 12 && _mounth <= 1)
                {
                    Console.WriteLine("Некорректный ввод!");
                    res = false;
                }
                return res;
            }
            public bool Year(int yaer)
            {
                bool res = true;
                if (_year <= 1)
                {
                    Console.WriteLine("Некорректный ввод!");
                    res = false;
                }
                return res;
            }
        }
        class ClientCard
        {
            public string _login;
            public string _ip;
            public string _email;
            public DateTime _data;
        }
        class Program
        {
            static void Main(string[] args)
            {
                var myMail = new email();
                var myLogin = new ClientCard();
                var myIP = new ipADDR();
                var myDate = new dateTime();

                string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string myLog = @"\kek.txt";
                StreamWriter myStream = new StreamWriter(path + myLog);

                Console.WriteLine("Введите логин: ");
                myLogin._login = Console.ReadLine();
                Console.WriteLine("Введите почту: ");
                myMail.setPost(Console.ReadLine());
                Console.WriteLine("Введите ip-адрес пооктетно: ");
                myIP.Input();
                Console.WriteLine("Введите дату заключения договора(день, месяц, год): ");
                myDate.Day(int.Parse(Console.ReadLine()));
                myDate.Mounth(int.Parse(Console.ReadLine()));
                myDate.Year(int.Parse(Console.ReadLine()));

                Console.WriteLine("Путь к папке МоиДокументы текущено пользователья: {0}", path);

                Console.WriteLine("Логин: {0}", myLogin._login);
                Console.WriteLine("Почта: {0}", myMail.getPost());
                Console.WriteLine("ip-адрес: {0}", myIP.Print());
                Console.WriteLine("Дата: {0}.{1}.{2}", myDate._day, myDate._mounth, myDate._year);

                myStream.WriteLine("Логин: {0}", myLogin._login);
                myStream.WriteLine("Почта: {0}", myMail.getPost());
                myStream.WriteLine("ip-адрес: {0}", myIP.Print());
                myStream.WriteLine("Дата: {0}.{1}.{2}", myDate._day, myDate._mounth, myDate._year);
                myStream.Close();
            }
        }
    }
}
