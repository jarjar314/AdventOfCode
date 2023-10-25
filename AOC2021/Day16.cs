using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Numerics;

namespace AOC2021
{
    public class Day16
    {
        public static void Main()
        {
            var list = new List<string>() { "D2FE28", "38006F45291200", "EE00D40C823060", "8A004A801A8002F478"
            ,"620080001611562C8802118E34","C0015000016115A2E0802F182340","A0016C880162017C3686B18A3D4780",
            "C200B40A82","04005AC33890","880086C3E88112","CE00C43D881120","D8005AC2A8F0","F600BC2D8F",
                "9C005AC2F8F0","9C0141080250320F1802104A08"};
            foreach (var l in list)
            {
                var packet = GeneratePacket(l);
                Console.WriteLine($"{l} : {SumVersion(packet)} : {packet.Evaluate()}: { packet.EvaluateBi()}");
            }
            var input = @"60552F100693298A9EF0039D24B129BA56D67282E600A4B5857002439CE580E5E5AEF67803600D2E294B2FCE8AC489BAEF37FEACB31A678548034EA0086253B183F4F6BDDE864B13CBCFBC4C10066508E3F4B4B9965300470026E92DC2960691F7F3AB32CBE834C01A9B7A933E9D241003A520DF316647002E57C1331DFCE16A249802DA009CAD2117993CD2A253B33C8BA00277180390F60E45D30062354598AA4008641A8710FCC01492FB75004850EE5210ACEF68DE2A327B12500327D848028ED0046661A209986896041802DA0098002131621842300043E3C4168B12BCB6835C00B6033F480C493003C40080029F1400B70039808AC30024C009500208064C601674804E870025003AA400BED8024900066272D7A7F56A8FB0044B272B7C0E6F2392E3460094FAA5002512957B98717004A4779DAECC7E9188AB008B93B7B86CB5E47B2B48D7CAD3328FB76B40465243C8018F49CA561C979C182723D769642200412756271FC80460A00CC0401D8211A2270803D10A1645B947B3004A4BA55801494BC330A5BB6E28CCE60BE6012CB2A4A854A13CD34880572523898C7EDE1A9FA7EED53F1F38CD418080461B00440010A845152360803F0FA38C7798413005E4FB102D004E6492649CC017F004A448A44826AB9BFAB5E0AA8053306B0CE4D324BB2149ADDA2904028600021909E0AC7F0004221FC36826200FC3C8EB10940109DED1960CCE9A1008C731CB4FD0B8BD004872BC8C3A432BC8C3A4240231CF1C78028200F41485F100001098EB1F234900505224328612AF33A97367EA00CC4585F315073004E4C2B003530004363847889E200C45985F140C010A005565FD3F06C249F9E3BC8280804B234CA3C962E1F1C64ADED77D10C3002669A0C0109FB47D9EC58BC01391873141197DCBCEA401E2CE80D0052331E95F373798F4AF9B998802D3B64C9AB6617080";
            var p = GeneratePacket(input);
            Console.WriteLine($"{input} : {SumVersion(p)} : {p.Evaluate()}: {p.EvaluateBi()}");

        }

        private static int SumVersion(Packet packet)
        {
            int count = 0;
            var q = new Queue<Packet>();
            q.Enqueue(packet);
            var sum = 0;
            while (q.Count > 0)
            {
                count++;
                var p = q.Dequeue();
                sum += p.Version;
                foreach (var next in p.Packets)
                {
                    q.Enqueue(next);
                }
            }
            Console.WriteLine($"{count} in this packet");
            return sum;
        }

        private static Packet GeneratePacket(string input)
        {
            var hexa = HexToBin(input);
            int index = 0;
            var packets = new Stack<Packet>();
            var headPacket = PacketHelper.BuildPacket(hexa, ref index);
            packets.Push(headPacket);
            return headPacket;
        }

        static string HexToBin(string hexstring)
        {
            return String.Join(String.Empty,
                                    hexstring.Select(
                                    c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')
                                )
                                );
        }

    }
    public class PacketHelper
    {
        public static Packet BuildPacket(string hexa, ref int index)
        {
            int v = 0;
            for (int i = 0; i < 3; i++)
            {
                v = 2 * v + hexa[index] - '0';
                index++;
            }
            int t = 0;
            for (int i = 0; i < 3; i++)
            {
                t = 2 * t + hexa[index] - '0';
                index++;
            }
            var packet = new Packet() { TypeId = t, Version = v };
            // Litteral value
            if (t == 4)
            {
                packet.IsOperator = false;
                long value = 0;
                bool notLast = true;
                while (notLast)
                {
                    notLast = (hexa[index] == '1');
                    index++;
                    for (int i = 0; i < 4; i++)
                    {
                        value = 2 * value + hexa[index] - '0';
                        index++;
                    }
                }
                packet.Value = value;
                return packet;
            }
            packet.IsOperator = true;
            var lengthTypeId = hexa[index] - '0';
            index++;
            if (lengthTypeId == 0)
            {
                var lengthOfSubPackets = 0;
                for (int i = 0; i < 15; i++)
                {
                    lengthOfSubPackets = 2 * lengthOfSubPackets + hexa[index++] - '0';
                }
                int end = index + lengthOfSubPackets;
                while (index < end)
                {
                    packet.Packets.Add(BuildPacket(hexa, ref index));
                }
            }
            else if (lengthTypeId == 1)
            {
                var numberOfSubPackets = 0;
                for (int i = 0; i < 11; i++)
                {
                    numberOfSubPackets = 2 * numberOfSubPackets + hexa[index++] - '0';
                }
                for (int i = 0; i < numberOfSubPackets; i++)
                {
                    packet.Packets.Add(BuildPacket(hexa, ref index));
                }
            }
            return packet;
        }
    }
    public class Packet
    {
        public Packet()
        {
            Packets = new List<Packet>();
        }
        public int TypeId { get; set; }
        public int Version { get; set; }
        public bool IsOperator { get; set; }
        public List<Packet> Packets { get; }
        public long Value { get; set; }

        public long Evaluate()
        {
            long res = long.MinValue;
            if (!IsOperator)
                res = Value;
            else
                switch (TypeId)
                {
                    case 0:res = Packets.Select(p => p.Evaluate()).Sum();break;
                    case 1:res = Packets.Select(p => p.Evaluate()).Aggregate((result, item) => result * item);break;
                    case 2: res = Packets.Select(p => p.Evaluate()).Min(); break;
                    case 3: res = Packets.Select(p => p.Evaluate()).Max(); break;
                    case 5: res = Packets[0].Evaluate() > Packets[1].Evaluate() ? 1 : 0; break;
                    case 6: res = Packets[0].Evaluate() < Packets[1].Evaluate() ? 1 : 0; break;
                    case 7: res = Packets[0].Evaluate() == Packets[1].Evaluate() ? 1 : 0; break;
                }
            return res;
        }
        public BigInteger EvaluateBi()
        {
            if (!IsOperator)
                return new BigInteger(Value);
            else
                switch (TypeId)
                {
                    case 0: return Sum(Packets.Select(p => p.EvaluateBi()));
                    case 1: return Mult(Packets.Select(p => p.EvaluateBi()));
                    case 2: return Packets.Select(p => p.EvaluateBi()).Min(); 
                    case 3: return Packets.Select(p => p.EvaluateBi()).Max(); 
                    case 5: return Packets[0].EvaluateBi() > Packets[1].EvaluateBi() ? BigInteger.One : BigInteger.Zero; 
                    case 6: return Packets[0].EvaluateBi() < Packets[1].EvaluateBi() ? BigInteger.One : BigInteger.Zero; 
                    case 7: return Packets[0].EvaluateBi() == Packets[1].EvaluateBi() ? BigInteger.One : BigInteger.Zero; 
                }
            return new BigInteger(long.MinValue);
        }

        private BigInteger Sum(IEnumerable<BigInteger> enumerable)
        {
            var res = new BigInteger(0);
            foreach (var elem in enumerable)
                res += elem;
            return res;
        }
        private BigInteger Mult(IEnumerable<BigInteger> enumerable)
        {
            var res = new BigInteger(1);
            foreach (var elem in enumerable)
                res *= elem;
            return res;
        }
    }
}
