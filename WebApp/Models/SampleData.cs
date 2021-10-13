using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class SampleData
    {
        public static void Initialize(SubscriberContext context)
        {
            if (!context.Subscribers.Any())
            {
                context.Companies.Add(
                    new Company {
                        Name = "К.С-Инвест",
                        Adress = "г.Чернигов, ул. Родимцева 14",//адрес
                        Phone = "+38 (0462) 614-681",//тедефон
                        Account = "UA133052990000026008006300527",//расчетный счет в банке
                        Code = "33660167",//код ЕДРПОУ
                        BankCode = "305299"// МФО банка
                    }
                );
                context.DomofonHandsets.AddRange(
                    new DomofonHandset
                    {
                        DomofonHandsetType = "SmartEl"
                    },
                    new DomofonHandset
                    {
                        DomofonHandsetType = "ТАП-02"
                    },
                    new DomofonHandset
                    {
                        DomofonHandsetType = "УКП-7"
                    },
                    new DomofonHandset
                    {
                        DomofonHandsetType = "УКП-12"
                    },
                    new DomofonHandset
                    {
                        DomofonHandsetType = "УКП-12М"
                    },
                    new DomofonHandset
                    {
                        DomofonHandsetType = "ВИДЕО"
                    },
                    new DomofonHandset
                    {
                        DomofonHandsetType = "Другое"
                    }
                );
                context.DomofonKeys.AddRange(
                    new DomofonKey
                    {
                        DomofonKeyType = "АДК"
                    },
                    new DomofonKey
                    {
                        DomofonKeyType = "Беркут ТМ"
                    },
                    new DomofonKey
                    {
                        DomofonKeyType = "Беркут RC",
                        DomofonKeyCode = "310"
                    },
                    new DomofonKey
                    {
                        DomofonKeyType = "Беркут RC",
                        DomofonKeyCode = "T470"
                    },
                    new DomofonKey
                    {
                        DomofonKeyType = "Беркут RC",
                        DomofonKeyCode = "2K4"
                    },
                    new DomofonKey
                    {
                        DomofonKeyType = "Беркут RC",
                        DomofonKeyCode = "T6K8"
                    },
                    new DomofonKey
                    {
                        DomofonKeyType = "Vizit RF-2.1"
                    },
                    new DomofonKey
                    {
                        DomofonKeyType = "Cyfral Dallas"
                    }
                );
                context.DomofonSystems.AddRange(
                    new DomofonSystem
                    {
                        DomofonSystemType = "АДК"
                    },
                    new DomofonSystem
                    {
                        DomofonSystemType = "Беркут"
                    },
                    new DomofonSystem
                    {
                        DomofonSystemType = "Vizit"
                    },
                    new DomofonSystem
                    {
                        DomofonSystemType = "Cyfral"
                    },
                    new DomofonSystem
                    {
                        DomofonSystemType = "Беркут SmartEl"
                    }
                );
                context.Adresses.AddRange(
                    new Adress
                    {
                        City = "Чернигов",
                        Street = "Ивана Мазепы",
                        House = 33,
                        Entrance = 4,
                        ContractNumb = "697",
                        FlatCount = 15,
                        DoorsCount = 1,
                        DomofonSystemId = 3,
                        DomofonKeyId = 7
                    },
                    new Adress 
                    {
                        City = "Чернигов",
                        Street = "Мстиславского",
                        House = 34,
                        Entrance = 1,
                        ContractNumb = "481",
                        FlatCount = 36,
                        DoorsCount = 1,
                        DomofonSystemId = 2,
                        DomofonKeyId = 4
                    },
                    new Adress
                    {
                        City = "Чернигов",
                        Street = "Попудренко",
                        House = 12,
                        Corpus = "Б",
                        Entrance = 3,
                        ContractNumb = "218",
                        FlatCount = 15,
                        DoorsCount = 1,
                        DomofonSystemId = 4,
                        DomofonKeyId = 8
                    }
                );
                context.Subscribers.AddRange(
                    new Subscriber {
                        Name = "Тамара",
                        Surname = "Мельникова",
                        Phone = "+380683871920",
                        Flat = 57,
                        ContractNumb = "221",
                        ContractDate = new DateTime(2010, 10, 21),
                        Code = "500697057",
                        AdressId = 1,
                        DomofonHandsetId = 3,
                        DomofonKeyId = 7,
                        Comments = "Хочет поменять на видеодомофон"
                    },
                    new Subscriber
                    {
                        Name = "Антонина",
                        Surname = "Вивденко",
                        Phone = "+380504652012",
                        Flat = 56,
                        ContractNumb = "220",
                        ContractDate = new DateTime(2010, 10, 20),
                        Code = "500697056",
                        AdressId = 1,
                        DomofonHandsetId = 4,
                        DomofonKeyId = 7
                    },
                    new Subscriber
                    {
                        Name = "Сергей",
                        Surname = "Шурубенко",
                        Phone = "+380502216025",
                        Flat = 59,
                        ContractNumb = "223",
                        ContractDate = new DateTime(2015, 11, 11),
                        Code = "500697059",
                        AdressId = 1,
                        DomofonHandsetId = 5,
                        DomofonKeyId = 7
                    },
                    new Subscriber
                    {
                        Name = "Андрей",
                        Surname = "Древа",
                        Phone = "+380685528956",
                        Flat = 5,
                        ContractNumb = "17",
                        ContractDate = new DateTime(2012, 12, 12),
                        Code = "500481005",
                        AdressId = 2,
                        DomofonHandsetId = 1,
                        DomofonKeyId = 4
                    },
                    new Subscriber
                    {
                        Name = "Владимир",
                        Surname = "Королёв",
                        Phone = "+38972689541",
                        Flat = 13,
                        ContractNumb = "23",
                        ContractDate = new DateTime(2014, 02, 16),
                        Code = "500481013",
                        AdressId = 2,
                        DomofonHandsetId = 2,
                        DomofonKeyId = 4
                    },
                    new Subscriber
                    {
                        Name = "Марина",
                        Surname = "Огурец",
                        Phone = "+380502020100",
                        Flat = 40,
                        ContractNumb = "20",
                        ContractDate = new DateTime(2017, 10, 20),
                        Code = "500218040",
                        AdressId = 3,
                        DomofonHandsetId = 3,
                        DomofonKeyId = 8
                    }
                );


                context.SaveChanges();
            }
        }
    }
}
