using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AOC2018
{
    public class Day2
    {

        public static void Main()
        {
            var input = @"ubkfmdjxyzlbgkrotcepvswaqx
uikfmdkuyzlbgerotcepvswaqh
uikfmdpxyzlbgnrotcepvswoeh
nikfmdjxyzlbgnrotqepvswyqh
qgkfmdjxyzlbgnmotcepvswaqh
uikfmdjxyzqbgnrytcepvsbaqh
uikfmdjxyzibgprotcecvswaqh
uikfmajxyzlcgnrojcepvswaqh
uvkfsdjxyzlbgnrotcepvjwaqh
uikfmdjxfzlbggrotcepvswawh
uikfmhjxyzlbgnuotcepvjwaqh
uikfmdjxyzlbuzcotcepvswaqh
uikfmdwxyzlbgnrotcepvfwamh
uikfmdexyzlbgnroecepvswhqh
uikfmdjuyzlbgnrotcqpvswafh
uikfddjxyzvbgnrotceppswaqh
yikfwdjxyzlbgnrotcepvswagh
uiktmdjxyzlbgnrotceposwajh
uikfmdsxyzlbgnroteetvswaqh
uikfpdjxyzlbgnroncepvswuqh
uikfmtjxyzlbgurotcepvswaoh
eikfmdjxyjlbgnrotcepyswaqh
uikfkdjxyzlbgnrotcepvszaqv
uikfrdjxtwlbgnrotcepvswaqh
uikfmdjxyzlbgnrotpepwswahh
kikfmdjxyzlbgnkotcepvswqqh
uikfkduxyzlbgnrotcepvswafh
uikfxhjxyzlbgnrotcegvswaqh
uikfmdjxyzlmgnrotcenvawaqh
uzkfmddxyzlbgnrltcepvswaqh
uikfmdjxyzlbgnrobcepisqaqh
uijfmdjxyzlbgnrotcexvrwaqh
uiwjmdjxyzlbgnrotceprswaqh
uhkqmdjxwzlbgnrotcepvswaqh
uiktmsjxyzwbgnrotcepvswaqh
uikfmdjxyztbgnqotcepvswcqh
uibfmdjxyzlbgnroqcepvswaqx
uwkfmdjxyxlbgnrotcfpvswaqh
uikumdjxyzlbgnrstceposwaqh
uikfzdjxyznhgnrotcepvswaqh
uikuydjxyzlbgnrotqepvswaqh
uikfmdqxyzlbgnrotfefvswaqh
yikfmdjxyzlbrnrqtcepvswaqh
uiifmdjxyzlbenrotcfpvswaqh
uxkjmdjxyzlbgnrotcmpvswaqh
uikgmdjxyzlbgnrotceovlwaqh
uikfmdjxyzvbgzrotcenvswaqh
uiufmdjxyzlbgnrotceposwazh
uiafmdjxyzlignmotcepvswaqh
uikfmdjxyzwbgnsotlepvswaqh
uikjmdjvyzlbgnrotcenvswaqh
uikfmdjxyzlbonroteepvswaqi
uikfmdjxyzldgnroxcepviwaqh
uikvmdjxyzlbgdrotrepvswaqh
uikfmdjyyzwbgnrotcepvzwaqh
uikfmdjxyzzbnnvotcepvswaqh
uikomdjxyzlbgnrotcepvuwhqh
uikfmmjxyzbbgnrotcepvswayh
uikfmdjfezlbgprotcepvswaqh
uzkfmojxmzlbgnrotcepvswaqh
uipfmdjxyzlbgnrotceyuswaqh
uikfmdjxyzlkgnmotcepvswadh
uikfmdjxyzlbgnuctcbpvswaqh
uikfqdjxyzlbogrotcepvswaqh
uikfmdjxyzlfynrotcepvswash
uikfmdjxizzmgnrotcepvswaqh
uhkfmdjxyzlbhnrotcenvswaqh
uipfmdjxyzlbgorotcepfswaqh
uikfmdjxyznbgnrotcepvswfah
uikfmujxyzlbgnrotnepvssaqh
uikfmdjxyzlxgnrotcepvsrwqh
uikfmdjxszlbgnrottvpvswaqh
umkfmdskyzlbgnrotcepvswaqh
uikfmdjxyzlbgorotcwpzswaqh
uikfmdhxyzzbgnzotcepvswaqh
jikfmdjxyzlbgnrotcepveyaqh
uirfmdlxyzlbgnjotcepvswaqh
uikfmdjxyzlbgnrorxepvswazh
uikfmdjxyzltgnrotcepvsxaqi
uikfmdjxyzlbxlrotcepkswaqh
uvkfmdjxyzlbgnrotcopvswxqh
uxkfmdjxkzlbgnrotcepvswqqh
uikfmdjxyzlbqnrotcepvhwrqh
uikfmdjxyzlvgnrolcepvswrqh
urkfmdixyzlbgnrotcepvsjaqh
uikfmdjxymlbsnrotcepvswcqh
uikfmdjxyilbgnrotcepvcwzqh
uikfadjxlzlbgnrotcepvswaql
uikfmdjxuzlbgdrotcgpvswaqh
yikfmdgxyzlbgnrotcepvswarh
uikfmdjxyzlbgorotcepcswaqv
uikkmdjxyzlbvnrotcepvvwaqh
uwzfmdjxyxlbgnrotcfpvswaqh
uikfmdjxyztbgnrotcrtvswaqh
uiufmdjxyzhbgnrotcupvswaqh
uikfzdjcyzlbgnrotcfpvswaqh
uipfmdjxyzlbgnrotavpvswaqh
uikfmajxyzlbgnrotcepbsxaqh
uikfmdjfyzlbgnrotbepvswmqh
gikkmdjxyzlbgnrptcepvswaqh
uikfmdjxqvlbgnrotsepvswaqh
fikfmdjxyzlbgnrotcegvswoqh
idkfmdjxyzlbgnrotcepwswaqh
uikfmdqxyzlbmnrobcepvswaqh
uikfmdjxyzpbgnroicepvsyaqh
uikfmkoxyzlbgnrotcgpvswaqh
unkfmdjxyzlbpnrolcepvswaqh
uikfmdjmyzlbgfrotcupvswaqh
ujkfmdjxynlbgnroteepvswaqh
uikfmljxyzlbgnaotcepvsiaqh
uikfmdjdyzlbgnrotcepvtwaqd
uikfmdjxyzlbgnyotcepimwaqh
uikfmdjxyzfbjnrotcepvxwaqh
eiwfmdjxyzlbgnrdtcepvswaqh
umkhmdjxyzlbgnrotceivswaqh
uikfmdjxyzlbgnrotcwpvswneh
uckfmdjxyzlbknrotcepvswauh
uiofmdjoyzlbgnrbtcepvswaqh
uikfmdbxyzlbgnrotcepaslaqh
uimfmdjxyalbgnrotcepvswaxh
uqkfmdjxyzlbwnrotcepmswaqh
uiyfmdjxyzlbgnrotcepvswxuh
uikfmdjxyzlbgmrotgepvswamh
uikfmdjxyqlbgarozcepvswaqh
uikfmdjxyzabanpotcepvswaqh
uikfmdjgyzlbsnrotcepvswaqj
uikfmdjxyzlbwnrottepvsvaqh
uikfmdjxyzlbbnrotcepvofaqh
uikfudjxyzlbgnustcepvswaqh
cskfmqjxyzlbgnrotcepvswaqh
uiwfmddxyzlbgnrotccpvswaqh
eikpmdjxyzlbgnrotcesvswaqh
uikfmdzxyzlngnrrtcepvswaqh
uikfmdjxyzlbgnrotcepaswtph
uirfmdjxyzlbgnrotcepvswsqe
uikjmdjxqzlbgirotcepvswaqh
uikfmdjxsllbknrotcepvswaqh
uikfmdjxyqlbgcrotcepvswaqu
uikfmdjsymlbgnrotcebvswaqh
uikfmdjxezlbgnroccepviwaqh
uikfmdjiyzjbgnrotcepvswarh
uqkfmdjxyzmbgnrotcepvslaqh
unkfmdjxyzlbinrotceplswaqh
uikfmdjxyzpbgnrjtcedvswaqh
uicfmdjxyzlbgrrotcepvswamh
ukknmdjxyzlbgnqotcepvswaqh
uikfudjxyzlbdnrztcepvswaqh
uikfmdjxyzlbgnrozcepvswawk
uikfmduxyzsbgnrotcepvswauh
uikfmdjxyzljbnrotcenvswaqh
uukfmdjxyzlbgnrotcckvswaqh
uilfldjxyzlbgnrotcdpvswaqh
uckfmdjxyvybgnrotcepvswaqh
qikfmdjxyglbgnrotcepvrwaqh
uikfmhjxyzltgnrotcepvswbqh
uikfmdjxipabgnrotcepvswaqh
uikfmdjxyzlbgnrotceovswanl
uikfmdjxyzlbgirotcapvswahh
uikfucjxyflbgnrotcepvswaqh
pikfmdjxyzpbgnrotcepvswaeh
uikfmdjiyylbgnrotcervswaqh
uikfmdjgyzlbgnrotcaevswaqh
uikvmdjxyzlbunrotcepvswarh
uikfadjuyzpbgnrotcepvswaqh
uikfmdjxyzlbgnrotcepsawaqj
eikfmdjxyflbgnrotcepvswaeh
uisfmdaxyzlbgnrotcepvswlqh
vikfmdjxyzlzgnrotcepvswanh
ukkfmdoxyzlbgnrotcewvswaqh
uikfmdhxyzlbgnrotcrpvbwaqh
uhkfmdjwezlbgnrotcepvswaqh
uikfddjxyzlbgnroteepvpwaqh
uikfmdjxczlbgncotiepvswaqh
uikfvdjxyzlbgnrotcnpvsaaqh
uikfmdjxyzlbgnritcepvlwmqh
uikfmdjxczlcgnrotcecvswaqh
mikfmdjxyzlbgnrotcepvswasi
uifvmdjxyzlbgnrotpepvswaqh
uikzmdjxyzlbgnrotrepvswaqs
uikfmqjqyzlbunrotcepvswaqh
uikfpdyxyzlbgnrotcepvswagh
uikfmdjxyzobgnrotrlpvswaqh
zisdmdjxyzlbgnrotcepvswaqh
uikfmdjxyzlbgnlotiesvswaqh
uikfddixyzlbgnroucepvswaqh
uijfmdrxyzlbgnrotoepvswaqh
uikfmdcxbzlbgnrotcepvpwaqh
uikfmdjxxzlbfnrotcecvswaqh
upkfmdjxyzmtgnrotcepvswaqh
uikfmdrxyzlbgnrjtcepvswaqp
uizfmdjxyzlbsnrotcepviwaqh
uidfmdjxyslbgnrotcxpvswaqh
uikfmdjxyzlbgnrovyepvsdaqh
uiafmdjxyzlbgnrxtcepvsdaqh
ugkfmdjxyzlbgnrodcepvswawh
pikfmtjxyzhbgnrotcepvswaqh
uikfmdjxyzlfgnvotcepvswtqh
uikbmdjxyzlbgerotcepvswaqm
uikfmdjxyhlbdnrotcepvswaqy
uikfgdjxyzlbgnhotcepvswdqh
uikfmdpxyzlbgnrotcepvscanh
uikfmdjxyzsbgnretcepvswaqn
uikfddjxyzlrgnrotcepvsbaqh
uikfmdjxyzlbgnrotcqnrswaqh
uhkfmejxyzlbgnrotvepvswaqh
uikimdjxyzlngnrotceprswaqh
uikfmdjxyzwbunrotiepvswaqh
rikfmdjxyzlbgnrotcypvssaqh
uikfmdjxyzlbdnrotcrpvswsqh
uekfmdjxkzlbznrotcepvswaqh
uikfmdjxyglbgvrotcepvswaqv
uikfmcjxyzlbgnrotmeovswaqh
uikfmdjxyznbgnrozcepvswaqm
uikfmdjxyzlbdnrotcepdsyaqh
umkfmdjxfzlbgnrotiepvswaqh
uitfmdjxyzvbcnrotcepvswaqh
uikfmdjqyzlbgnrvtcepvlwaqh
uikfmdjxyzkbworotcepvswaqh
uikfmdzxyzlbwnrotcypvswaqh
uikfmdjxyklbgnrftyepvswaqh
uinfmsjxyzlbgnrotcepsswaqh
xisfmdjxymlbgnrotcepvswaqh
uikfmdjxjzlbgnropcepvswaqv
uikfmdjxyalegyrotcepvswaqh
uikfydjxyzlbgnrotcekvswtqh
uikwmojxyzlbgnromcepvswaqh
uikdmdjayzlbgnrotcepvswzqh
uikfmdjxyzlmvnrotctpvswaqh
uikfmbjxyzlbgnrotceptsweqh
yvkfmdjxyzlbgqrotcepvswaqh
uikomdjxfxlbgnrotcepvswaqh
uikfmdjxczlbgnroocepgswaqh
uikemdjxizlbgnrotcegvswaqh
uikdmdjxyzlbgwrotceprswaqh
tiyfmdjfyzlbgnrotcepvswaqh
tmkfmdjxyzlbgirotcepvswaqh
uikfmdjxyzebgnzotcepqswaqh
uikfmljxyzlbgnrwtcepvswaeh
uikfmojxyzlbgnrotcepbswwqh
uikfmdjxyzlbgsrotcewvswwqh
uikfmdjhyzlbgdrogcepvswaqh
uikfmvjxyzlbrnrltcepvswaqh
jikfmdjxyzlbgnrotcepvgcaqh
uikhtdjxyzlbgnrotcepvswarh
uikfmdjxyezbgnritcepvswaqh
uikfwdjxyzlbgnrotzepvsnaqh
uikfmdjxqylbgnrobcepvswaqh
zikzmdjxyzlbgnrhtcepvswaqh
uiksmzjxyzlbgnrftcepvswaqh
uikfmdjxuzlbgnrotcepvsvaqc";
            var pass = input.Split(new[] { ' ', ',', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            int c2 = 0, c3 = 0;
            foreach (var i in pass)
            {
                var gr = Group(i);
                c2 += gr.Contains(2) ? 1 : 0;
                c3 += gr.Contains(3) ? 1 : 0;
            }
            Console.WriteLine($"{c2}*{c3}={c2 * c3}");
            for (int i = 0; i < pass.Length; i++)
            {
                for (int j = i + 1; j < pass.Length; j++)
                {
                    if (Diff(pass[i], pass[j]) == 1)
                    {
                        Console.WriteLine($"{pass[i]}\n{pass[j]}");
                    }
                }
            }
        }

        private static int Diff(string v1, string v2)
        {
            int d = 0;
            for (int i = 0; i < v1.Length; i++)
            {
                if (v1[i] != v2[i]) d++;
            }

            return d;
        }

        private static HashSet<int> Group(string s)
        {
            return s.GroupBy(c => c).Select(gr => gr.Count()).ToHashSet();
        }
    }
}
