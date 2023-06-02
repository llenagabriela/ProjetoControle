using System.Linq;
using System.Data;

namespace ProjetoControle.Models
{
    public class ParkingControl
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public string DataEnt { get; set; }
        public string DataSai { get; set; }
        public string TimeEnt { get; set;}
        public string TimeSai { get; set;}
        public string Duracao{ get; set;}
        public string TimeCobr { get; set; }
        public string Preco { get; set; }
        public string ValorPag { get; set; }

        public ICollection<ParkingControl> Parking { get; set; } = new List<ParkingControl>();


        public ParkingControl() {
        
       
        }

        public ParkingControl(int id, string placa, string dataEnt, string dataSai, string timeEnt, string timeSai, string duracao, string timeCobr, string preco, string valorPag)
        {
            Id = id;
            Placa = placa;
            DataEnt = dataEnt;
            DataSai = dataSai;
            TimeEnt = timeEnt;
            TimeSai = timeSai;
            Duracao = duracao;
            TimeCobr = timeCobr;
            Preco = preco;
            ValorPag = valorPag;
        }

        public void AddParking(ParkingControl pc) 
        { 
            Parking.Add(pc);
        }

        public void RemoveParking(ParkingControl pc)
        {
            Parking.Remove(pc);
        }

        public double TotalParking(String placa)//DateTime initial, DateTime final, TimeOnly timeeini,TimeOnly timeend)
        {
            Parking.Where(pc => pc.placa = placa);

            foreach (ParkingControl pc in Parking)
            {
                if (Parking >= ParkingControl.DataEnt) && (Parking <= ParkingControl.DataSai)
                {
                    if ((TimeEnt - TimeSai).Hours == 0) && ((TimeEnt + TimeSai).Minutes <= 30)
                    {
                        return double total = 1;
                    }
                    else if ((TimeEnt - TimeSai).Hours > 0) && ((TimeEnt + TimeSai).Minutes > 10)
                    {
                        return double total = total + 1;
                    }
                }



            }
        }
    }
}
