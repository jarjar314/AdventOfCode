﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;

namespace AOC2023
{
    public class Day19
    {

        public static void Main()
        {
            var input = @"qn{s<3093:R,R}
vd{s>1104:ls,qq}
zrk{x<529:R,m>2107:R,x>842:R,A}
dcb{s<3074:dpl,s<3415:bkf,x>1024:kzj,cv}
qdq{a<2983:R,A}
dfh{s>2633:R,a>1549:R,zrk}
ft{x>2295:R,A}
rx{m<2891:fj,a<1392:nn,dl}
vdn{s<3520:R,s>3733:R,A}
phr{x>1406:tm,a<618:bj,rsz}
jn{x>511:A,m>2075:R,a<584:A,R}
gfl{x>1359:A,a>3751:kfv,jhz}
ldg{m>1833:jvc,s>226:ck,R}
fnp{m<1441:stz,a>3225:nst,x>1491:qhg,gjh}
qkc{a>689:kxs,x>3124:dcq,R}
pf{s>1125:A,A}
fm{s>3659:R,A}
vnn{m>1491:R,s>2406:ztc,a>3716:R,fdg}
dvn{s>1612:sp,a<736:vfd,rx}
zxh{s>487:R,x>3635:R,x<3556:R,A}
xmp{a>3109:R,x<2607:A,s<3192:R,qt}
tm{x>1898:mnl,a>478:R,s<3323:A,R}
cqc{x<1598:R,x<1975:A,R}
dcq{x<3448:A,R}
rjk{a<546:kfz,m>1333:A,s>1212:A,A}
rj{s<387:A,R}
mnl{s<3169:A,x<1987:R,A}
vrt{s>876:A,A}
mmt{m>302:gf,a>830:mt,m<171:cpg,fk}
nl{s<1873:mk,x>1866:bkp,R}
jx{a>2277:R,R}
cgj{s>1593:zj,x>2636:A,R}
zj{x<2591:R,m>1537:R,x>3082:R,A}
bc{m<3724:R,m<3874:A,A}
xcj{x>2159:rk,a<1129:thk,m>1672:lz,kk}
jgs{x>924:gsr,mkc}
rn{x>3612:R,x<3429:A,m>3840:A,A}
hp{a>1522:cdx,s>2339:gj,A}
gv{x>610:zdq,m>2839:mht,ts}
xsl{m>2448:R,R}
qx{x<707:hzk,R}
fjp{a>3719:R,a>3639:A,jr}
gz{m<3370:R,a<3207:A,x>2600:R,A}
cr{s<371:R,s>531:R,rhj}
xt{m>1654:A,m<771:R,m<1170:R,A}
ng{m>2823:tk,R}
ltf{x>1700:R,x>859:fh,mc}
ln{s<991:xk,s>1368:rl,m>1582:nt,vtz}
dxh{a<624:ph,fl}
dg{m<3013:A,A}
vpk{x<1004:ckf,s<1199:th,rct}
zxx{x<1044:A,x>1615:A,rd}
pj{s>2865:R,A}
rpt{s>467:rtz,kmp}
vsf{x>3224:R,a>2147:R,A}
qbb{s<174:A,A}
dvf{m>457:A,x>946:A,R}
hpk{m<2942:A,R}
in{a<1847:rc,fd}
tb{m>3327:hd,m>2818:qpn,s>1448:qbl,vb}
jd{m>2502:qbb,x<3036:R,cg}
pnt{a<2408:A,R}
nbm{m<3079:R,A}
xc{s>3319:mf,s>2745:R,x>2633:dr,cvr}
xn{a>191:A,m<1045:A,s>3424:A,A}
rt{s>555:kld,x>1870:jvg,s<306:rg,pjp}
mks{s<3239:R,A}
sm{m<3327:A,A}
tpp{a>2021:ltk,a<1936:A,A}
qqk{x<2881:R,m>3385:A,R}
pv{m>2192:A,a>1575:R,x>1750:A,R}
mvs{s>1339:R,a>1226:A,R}
dl{m>3400:R,s<1121:A,nv}
bpn{a<2121:rvg,spj}
zf{s>1474:R,m<2580:A,R}
mht{a>3577:R,A}
dm{x<1024:A,a>408:A,lmc}
gng{m<2362:R,A}
dd{s>954:R,m>3586:R,m<3360:R,R}
hhf{x>562:R,m<2860:A,m>3581:R,R}
qm{s>1462:R,R}
kkh{m>3305:R,x>1544:R,R}
hlt{s<3610:lj,jlz}
fj{x<933:xs,s<1218:R,x>1922:czl,A}
jl{x>607:A,A}
dt{x>2111:vp,s>1269:dm,a<696:ggb,hz}
zd{s<1099:R,A}
gkg{a<1170:R,R}
qh{m>1476:A,a<3898:R,s<1993:R,R}
dmr{a<2235:A,x<3173:qj,s<610:qd,xt}
pvr{a<2158:hpk,qrq}
sxc{x>2414:jtp,s>954:vpk,m>2406:dkn,xfz}
gjh{x>940:fc,x<528:md,s>3096:pls,tbn}
hqz{x>925:R,kn}
cz{m<3883:R,m<3935:A,a<1643:R,R}
nzv{m>2283:ntg,s<717:qf,R}
frv{s<2399:znm,s<2655:flz,mxb}
xkp{m<986:hr,ln}
ssk{a>2345:br,s<683:bs,lns}
vfd{s<1234:jz,s>1370:bfj,m<3401:ng,ghb}
zdb{m>2603:A,a>3140:A,s<2903:A,A}
gh{a>1246:R,R}
lv{x<571:A,R}
kcc{m<1278:lgn,x>3442:zxh,A}
mt{m<103:R,x>2156:A,a<1497:R,R}
rmn{m<948:A,s<1852:R,x<338:A,R}
fx{m<765:rcz,m>1146:A,nnj}
bx{s>1228:fbc,s<1086:zb,jjs}
pbv{x>3092:R,m>2111:R,a>2687:qnv,A}
jz{x<1741:R,s>1016:sg,R}
nh{m<2308:A,R}
smc{a<3405:A,x<2014:xqv,s>1913:mp,A}
lh{a>3100:R,R}
dfc{s>1098:R,m<901:A,x>1990:pzm,rj}
qkk{m<2524:R,R}
qhg{s<2561:cq,xmp}
rg{s>189:nbm,qx}
qfs{m<607:tg,x<1129:zzc,R}
qf{x>3214:A,x<2518:R,s>333:A,R}
nqv{s>1901:R,x<370:A,a>3806:A,R}
bmc{x<3390:A,m>1940:A,A}
nv{s<1335:R,m<3188:R,A}
dj{s<3260:kf,x<388:mzp,m>2522:rgx,hg}
sxm{x>942:ztg,m<1458:A,m>2689:lzq,vpg}
hjg{m<963:R,R}
tpf{s>265:A,m<2096:R,a<2612:A,A}
htz{x<2067:A,R}
hbv{a<2992:A,x>2263:R,R}
hd{s<1265:vd,x<3266:hq,prq}
tq{s<1366:R,R}
xb{x>654:ss,kkr}
kmp{x<2056:bq,x<3241:df,s>235:cpp,nsb}
kzj{m<1694:R,x>1307:R,R}
jjs{m<1214:R,s>1159:R,m<1422:A,R}
rcz{s<3003:R,x>3275:R,a>2901:A,A}
shb{m>764:R,R}
zn{s<2827:A,R}
mnc{s<2352:R,R}
xrl{m>1721:A,x>258:R,R}
gnn{s<3489:bdb,mtd}
dpr{m<2983:qkk,htz}
mxk{a>2944:rrs,R}
zrg{s>1288:R,x<3061:A,a>1011:A,qg}
rk{m>2453:ffx,jq}
ntg{a<2431:R,m>2867:A,x>3017:R,R}
gb{a<1322:A,s>3388:A,vr}
sk{s<3427:R,a>3143:A,a<3096:R,A}
rh{s<2430:R,A}
xnf{s>68:A,s<42:A,R}
vb{s<1151:qkc,m<2480:xd,x<3519:zrg,vss}
gnv{s>445:R,a>2867:R,x<3219:A,A}
ps{m<2798:gzr,s>2148:A,dqb}
ggm{x<554:A,s>3264:A,s<3157:A,R}
br{a<2496:nrc,x>1387:vfg,m<1583:shv,hhq}
cp{a<546:A,R}
rsz{s<2985:mgm,s>3406:A,x>1151:A,R}
pn{a<1743:R,s>2696:A,A}
bfl{s<129:A,x<1866:A,R}
bfj{a>468:A,x>910:A,gsd}
nrc{x>2151:nzv,vjq}
bj{m>1724:vjv,s>2991:R,rh}
pg{m<669:A,a<223:A,A}
ql{s>2583:A,x>1787:R,x>1532:R,A}
xrx{s>851:A,a>2963:nr,s<711:A,R}
rrk{m>1712:A,x>2268:R,a>405:A,R}
mm{a>3479:A,A}
bmv{m<1730:A,m<2948:R,R}
stz{s>2492:ltf,a<3249:ktf,smc}
kfz{m>1292:R,s>1193:A,x<2382:A,R}
pc{m<1834:A,x<3627:R,x<3788:R,R}
ts{s<527:A,A}
mc{a<3358:A,x>410:R,A}
rgx{a<147:A,a>272:A,s>3628:R,R}
pjp{x<904:gg,sj}
csf{m>2875:A,A}
kp{x<603:R,m>559:A,A}
gf{s<1773:A,a>833:R,a>480:A,R}
txp{m<2430:R,A}
lz{m<2533:nx,m<3386:smf,s<3097:jm,gnn}
vr{x>362:R,m<1434:R,R}
trz{s<783:hbv,s<921:qdq,x<2031:dd,R}
rct{m>1432:tq,m<928:hfs,qm}
ls{s<1167:R,s>1201:A,x<3491:A,A}
njv{s<2185:A,R}
nlx{x<1610:dcb,xvk}
vtz{a>911:bx,rjk}
vdk{s>3165:A,A}
fp{s<161:A,a<2939:A,A}
th{s>1040:R,s<1009:cqc,A}
gs{s<136:R,x<1652:A,R}
xrv{s<2456:R,tc}
pp{x>382:zn,m<1630:zkh,csf}
dhv{x<2824:fcm,m<3151:A,s<352:fp,gnv}
vss{x>3804:A,A}
spj{a>2247:A,pf}
bkp{x>2830:A,s<1976:R,R}
jcm{x>785:R,s<623:A,zcd}
nt{s<1165:mnd,ct}
bxv{s>1452:A,A}
hfh{m<3082:A,A}
zb{m>1367:A,m<1137:R,A}
jfr{s>1381:gn,R}
vpg{x<598:R,R}
bdh{m<3237:R,s>2027:R,a>627:A,R}
mkc{x>528:vx,A}
ktf{x>2285:ppb,a<3125:bp,hpl}
xps{a>956:R,km}
cv{x>657:R,a<2840:A,m>2228:A,vnc}
fnb{a<2543:A,a<2580:bmc,a<2590:R,A}
zjj{a>952:A,R}
xfx{x<294:cp,a>520:jn,A}
ppb{x<2999:R,R}
bdb{a<1411:A,a>1653:fgt,A}
zgs{s<3806:A,s<3873:A,R}
hzf{a>1322:R,s>3455:R,R}
ndr{s<766:jtm,mxk}
tbn{s<2599:A,s<2786:A,m<2722:A,A}
zjf{s<3324:pnt,s<3692:ptg,a<2236:R,xdq}
kk{a>1414:tqk,s<2848:sn,a<1275:jgs,rvb}
qlx{s>274:gz,A}
hm{s<1598:nc,m>3057:mmh,x<3152:R,A}
ffx{m<3300:dxz,x<2918:mfg,hl}
shv{s<1063:lv,jfr}
lmd{m>1090:A,m>1053:R,x>1425:R,R}
jvc{a<2275:A,s>205:A,A}
fbc{m>1347:A,m<1111:A,A}
fd{s>1605:bt,a>2761:kt,ssk}
dr{s>2507:A,x>3061:A,R}
rr{a>1240:jp,sl}
ct{m<1871:qz,A}
zjg{x>3145:hfh,a<855:jsn,R}
ggb{x<819:fv,x>1622:zh,bn}
qrq{s>1115:A,ddd}
fvb{x>1302:R,x>700:A,s>1729:A,A}
czl{x<2376:A,a>1338:R,a<987:A,R}
jrm{s>645:R,x>3588:R,A}
xk{s>658:tvz,m>1557:xj,jnh}
vv{m>2055:R,s<279:R,A}
kjz{x<3014:A,A}
plc{s>3625:zbs,m>1928:vsf,hld}
lns{m>1656:pvr,x<1724:bpn,hfx}
fv{s>767:R,R}
kf{a<191:pj,a<287:dtm,xrl}
zbs{x<3277:R,s>3813:R,m>1507:R,A}
nc{s<1399:A,A}
fn{s>320:A,m<3405:bfl,bc}
fcm{s>187:R,a<2945:A,m<3176:A,A}
mdb{a>3771:R,m>2652:R,A}
pr{s>2555:sxm,s>2469:gfl,x<1011:lq,vnn}
gfd{x>1730:gk,R}
rlj{x<998:R,A}
fb{m>535:A,R}
vdj{x<2831:A,a<200:R,a>264:A,A}
sp{s>1906:lzn,a<1051:nqb,a>1402:sx,rr}
fgt{m<3784:A,a>1738:R,a<1698:R,R}
fdg{s<2385:A,m>667:A,A}
hpl{s<1909:R,R}
gk{x>2743:R,x<2392:R,R}
cq{s>1975:njv,s<1794:txz,s<1860:R,kx}
hps{a>2023:A,s>151:A,R}
fq{a<1226:A,a<1568:R,R}
xs{s<1104:R,A}
cpp{m<3294:px,lr}
nm{a<1622:A,R}
zxn{a>2426:nd,x>671:rdz,lc}
tp{m>2983:A,R}
jhz{m<1564:A,s>2522:A,s>2489:A,A}
fpx{x>3445:trl,pql}
sl{x<1517:R,a>1126:R,A}
lvg{s<3304:qn,R}
tjf{a<744:R,R}
jtm{s>388:mj,R}
lhc{a>3602:A,x>1554:R,s>307:A,A}
pvl{s>1128:A,R}
zz{m>1080:R,x<441:R,s>255:R,A}
pmk{s>529:dmr,x<3450:txp,bh}
nn{a>985:gkg,R}
jtp{m<2452:plr,a>3700:mv,m>3455:knm,xrk}
gsd{s<1514:A,A}
rdz{x<1284:R,A}
tg{m>273:R,x<1126:R,m>171:R,R}
vk{m<2634:A,a<1939:R,R}
lzn{x<1321:fq,x<2009:bdh,A}
jr{s>2037:R,x>2777:A,A}
hg{s<3616:xn,s>3866:R,A}
tc{s<2730:R,R}
fg{x>598:A,s>2091:R,m>1598:nqv,rmn}
tqk{s<2914:gsp,hlt}
jfv{a>3763:qh,a>3666:A,R}
qc{a<2922:R,m<3063:sfv,R}
prq{m>3728:rn,m<3509:A,s>1744:dq,R}
gx{x>2779:A,A}
bq{s>164:sqt,dg}
gzk{x>2944:A,x<2484:R,s>3121:R,R}
bt{a<2728:kkt,a>3538:cl,a>3045:fnp,nlx}
hfk{a<1948:R,s>494:R,R}
mgm{s<2420:R,A}
fc{x>1234:A,s>2769:sk,gng}
zqk{s<235:qgh,s>279:lhc,x>876:R,zz}
mnd{s<1089:tjf,s>1114:R,R}
gsr{s<3544:A,A}
sng{m<2770:A,s>617:R,m>2835:R,R}
ztv{s>1405:mmt,s>680:pvl,cr}
nd{x<1094:A,x>1477:A,R}
qz{a>691:A,s<1250:A,A}
nkk{s<618:A,s>746:R,A}
ph{a<280:R,A}
vjv{s>2896:A,A}
vfg{x<2479:mx,a>2599:pbv,fnb}
rf{a<2941:hqz,zxx}
hl{x>3527:R,m>3720:A,x>3243:vn,R}
dqb{x<3307:R,m>3345:R,x<3709:R,R}
sx{a<1650:R,sm}
kh{s<820:rpt,x<2612:dvn,tb}
lgn{a>2076:A,x<3342:A,R}
jb{s>618:A,x<2106:R,a<659:kzx,nxr}
bv{x<2050:dvh,x>3244:R,R}
zh{m<727:A,x<1837:A,R}
ckf{m>2201:R,s<1210:R,bxv}
ss{x<947:R,x<1303:R,m<3704:R,A}
kld{s>1009:dpr,m<3247:xrx,trz}
jhr{s>3263:A,cm}
hhq{s>607:fxz,vpb}
rvg{m>955:jl,R}
hfs{x>1858:R,s<1382:A,s<1521:A,R}
gzr{m<2318:R,x<3490:R,a>2870:R,R}
sqt{x<1011:R,s>349:A,A}
bk{s<1573:R,R}
jxr{m>2546:R,x>3345:R,A}
ftr{a>798:xps,a<673:xfx,pp}
dcl{m<1002:dvf,s>108:A,m>1722:xnf,R}
kzx{m<3392:A,R}
kfv{s>2500:A,R}
kdz{a>1083:R,A}
zzc{a<1272:R,a>1326:R,R}
hzk{a>2981:R,x<330:R,R}
tvh{x>2435:ndr,rf}
svh{m>2171:tpp,a>1986:kcc,rfg}
xd{m<2372:A,mvs}
tf{x<3237:R,m<1514:R,R}
sg{a>278:A,a<141:R,m<3280:A,A}
jp{m>2988:A,m>2596:A,s<1789:R,A}
kg{a>1669:R,cnr}
bh{x>3677:A,s>451:A,pzl}
qd{x<3631:A,R}
mzp{m>1682:jks,s>3738:A,x<236:pg,nk}
nqb{m>3216:fvb,x<1399:fvv,R}
zdq{s<322:A,a<3520:A,x>1018:R,R}
qj{s>607:A,m<1804:A,R}
mj{m<915:R,R}
ftq{s>963:R,m>841:A,x<2558:R,A}
fnh{s>1291:A,R}
ddd{x>1419:R,s>963:A,m>2516:A,R}
qk{x>1598:A,R}
xlf{a<2076:vk,x<1516:A,A}
rl{s>1727:nl,x<1506:zjj,cgj}
jsn{a<501:R,a<639:R,s<923:R,A}
fvv{m>2803:A,R}
vnc{s>3718:A,a<2968:A,m>1350:R,A}
mk{x<1552:A,R}
px{a>704:A,R}
znm{x>3697:R,a>3782:A,R}
xgx{a>3166:A,a>3088:R,R}
zcd{m>3334:R,s>738:A,A}
flz{s>2493:A,s>2448:A,x<3626:A,R}
qgh{m>1141:A,A}
lnk{x<763:tp,A}
gg{s>428:R,a>3086:R,hhf}
dvh{m>648:R,s>1356:A,s>640:R,R}
krk{s<3462:A,m>1380:fm,a>1354:qk,lsr}
hfx{m<1040:fb,a>2128:zd,lfk}
ghb{a>416:R,A}
nr{m<2887:R,m>3094:A,A}
smf{a>1562:kg,lnk}
cnr{s>3362:A,s<2932:A,R}
lzq{a<3717:A,x>448:R,a>3865:A,R}
qt{x<3130:A,s<3558:A,s<3767:A,R}
cl{s>2803:sxt,x>2261:npb,s<2359:cgt,pr}
kkr{s<401:R,a<3455:A,A}
sd{m<981:A,x>1049:A,A}
thk{x>751:phr,a<428:dj,ftr}
xqj{x<895:mhn,xlf}
ff{x>3487:A,A}
ht{a>2155:ldg,jd}
bs{x<2458:xqj,s<366:ht,a<2149:svh,pmk}
lq{s<2426:A,s<2441:A,a<3776:R,R}
zmm{a<783:ff,gh}
lfk{m>1260:R,A}
clj{m>384:hzf,R}
qlg{s>2825:zjf,zxn}
cvr{x<2365:R,m<1236:R,R}
lsr{x<1680:A,x<1939:A,a>1313:A,A}
cg{a>1998:R,m>1101:R,s<180:A,R}
rfg{a<1915:A,hfk}
pzl{x<3568:A,s>409:A,R}
dq{x<3685:R,s>1933:A,A}
kxs{m<2481:R,m>2696:A,m<2574:A,A}
lr{m<3583:A,x>3739:A,x>3513:A,A}
nnj{x>3329:A,x<2922:R,s>3167:A,A}
bkf{x<885:ggm,m<1914:A,m>3143:mks,tn}
xqv{x<695:R,A}
jvg{a<3041:dhv,a>3130:qlx,lh}
kt{a>3253:sxc,m<2264:tvh,rt}
mhn{s>375:bmv,m<2419:hps,R}
zkh{a>748:R,A}
bn{a<322:A,A}
tk{a<287:R,R}
xfz{s>323:sd,s>188:zqk,dcl}
hld{x<3138:A,s<3337:R,s>3493:R,A}
tvv{x<2884:jx,s<2963:fpx,x<3487:plc,lzz}
rd{x>1358:R,a<3116:A,m>1143:A,A}
zdr{s>1987:R,x<3328:A,A}
fh{m>936:R,m>351:R,x>1299:R,A}
npb{m<1648:mnc,x<3243:fjp,frv}
hr{m<591:ztv,a<1209:dt,jh}
nx{x>1046:gd,s>2812:lvg,s<2530:hp,dfh}
ltk{m>2857:R,a<2089:R,a<2111:A,R}
vqm{a>2443:A,m<2666:R,A}
gd{s>2742:mgx,pv}
jh{m<749:bv,a<1600:xr,dfc}
mf{s>3709:R,A}
sj{a<3008:kkh,s>444:R,s>361:A,xgx}
vm{x<1809:R,m>560:A,A}
rvb{m<997:clj,x>998:krk,gb}
nst{a>3433:mm,a<3363:gfd,bzq}
tz{a>1207:A,a>504:A,m>3639:R,A}
vx{x>731:R,A}
rtz{x<1510:jcm,x<3016:jb,jrm}
dpl{s>2511:A,R}
fxz{m>2984:R,m>2463:R,x<682:A,R}
cm{a>3719:A,x>1519:A,m>2600:A,R}
dv{x>2917:R,x>2789:R,R}
nf{a<2423:R,m<1464:R,R}
xdq{m<1981:A,a>2525:R,A}
sxt{x<2507:jhr,s<3371:tf,s>3582:nh,clc}
dkn{x>1483:fn,m<3300:gv,a>3664:nkk,xb}
rc{s>2109:xcj,m>2310:kh,xkp}
trl{x<3746:A,a<2207:R,R}
qpn{s>1254:hm,s>1061:lpz,zjg}
kx{x<2412:A,s<1916:R,R}
km{x>336:A,a<861:R,A}
tvz{a>989:vrt,rrk}
qbl{s>1688:kz,zmm}
pzm{a>1746:A,s>681:R,a>1682:A,A}
knm{m>3661:R,A}
rhj{a<736:A,x>1349:A,A}
dxz{a<1098:gx,R}
gsp{x>1285:vm,m<726:A,R}
gn{a<2644:R,s>1460:R,s<1423:R,R}
bp{m<817:R,R}
jq{x>3281:dxh,xc}
lzz{s>3386:R,R}
rrs{a<3149:R,A}
cpg{m>70:R,R}
hz{s<614:A,R}
lj{m<1062:A,s<3220:R,R}
jlz{a<1668:A,x>1349:A,m<640:A,R}
fl{a>1037:R,x<3676:A,R}
dtm{s<2514:R,x<454:R,x>607:A,R}
mv{s>1038:fnh,R}
df{x<2665:ft,qqk}
ztc{x>1809:R,A}
clc{s>3510:kjz,m<1976:A,s<3459:mdb,ggh}
lc{s>2284:R,x<304:R,x<535:A,R}
vn{x>3424:A,A}
kn{x>562:R,m<1475:A,A}
cdx{x<481:R,A}
ck{x>3380:A,s<313:A,A}
mxb{a>3755:A,a<3674:R,A}
kz{s>1873:zdr,m>2502:R,s<1781:A,R}
vpb{m<2893:tpf,x<863:A,A}
vjq{s<1020:nf,s<1332:vqm,zf}
zln{m>2243:A,A}
txz{m>2744:A,a>3163:R,x>3075:A,A}
tn{a<2842:A,a>2937:R,R}
txf{x>3070:A,R}
ptg{x<1192:A,a<2201:A,a>2478:R,A}
hq{a>885:A,a>385:dv,vdj}
qnv{a<2721:A,R}
vl{x>1653:A,s<891:R,R}
jm{a<1589:rlj,m>3628:xrv,pn}
fk{s<1871:A,s<1997:A,A}
pls{x>683:vdn,R}
xj{x<2398:R,x<3082:vv,pc}
mgx{m>2125:R,x<1759:A,R}
lpz{a>1117:R,a<534:A,m<3076:R,R}
xrk{m>2889:txf,m>2599:sng,s<688:jxr,A}
qg{m<2698:R,a<438:A,R}
mx{s<805:A,m>1704:R,R}
xvk{x<2528:xsl,m<1413:fx,s>2856:qc,ps}
mp{x<2743:R,s<2140:A,m>559:A,A}
lmc{s>1773:A,a>215:A,A}
mfg{a<1137:R,s<2894:R,s<3522:vdk,zgs}
plr{a>3510:hjg,x>2952:A,R}
ztg{m>1503:R,a>3820:A,a>3671:A,R}
jks{m>3068:A,x<187:A,A}
mtd{a<1446:A,m<3751:A,s<3683:cz,nm}
sfv{s>3617:R,s>3289:A,s>3035:A,A}
htr{x<3238:R,x<3552:R,s<614:R,A}
nsb{s<110:R,m<3120:R,x<3512:R,tz}
md{x<230:R,zdb}
ggh{m<3154:A,R}
nk{s<3421:A,m<1065:A,s>3621:R,A}
jnh{m<1231:lmd,s<249:gs,x<2205:kdz,R}
bzq{a<3400:A,m<3030:zln,x>1742:gzk,R}
kkt{x>1827:tvv,qlg}
vp{s>1058:bk,a<606:shb,x>2795:htr,A}
cgt{x<1500:fg,jfv}
gj{x>655:R,m>2239:A,x<244:R,R}
nxr{m<3107:A,A}
sn{x<990:kp,x<1396:qfs,ql}
pql{m<2260:R,s>2172:R,A}
mmh{s>1879:A,R}
qq{a>844:R,a<517:A,x>3435:R,A}
xr{m>860:vl,m>809:ftq,A}

{x=1129,m=1499,a=669,s=1670}
{x=1233,m=652,a=1001,s=965}
{x=420,m=1477,a=1481,s=55}
{x=1067,m=243,a=1097,s=989}
{x=7,m=520,a=217,s=6}
{x=1161,m=273,a=2705,s=725}
{x=145,m=462,a=1473,s=872}
{x=932,m=2862,a=1975,s=1197}
{x=1581,m=287,a=143,s=1681}
{x=2965,m=79,a=788,s=3266}
{x=655,m=487,a=13,s=2530}
{x=1751,m=1503,a=126,s=502}
{x=1244,m=168,a=348,s=136}
{x=1948,m=602,a=227,s=394}
{x=2235,m=199,a=2207,s=237}
{x=203,m=27,a=1449,s=54}
{x=2995,m=161,a=1272,s=2246}
{x=1303,m=833,a=5,s=2616}
{x=126,m=772,a=88,s=772}
{x=407,m=1128,a=585,s=1854}
{x=127,m=965,a=40,s=142}
{x=1759,m=41,a=2028,s=2797}
{x=654,m=160,a=87,s=2620}
{x=2255,m=1072,a=487,s=1307}
{x=292,m=563,a=2773,s=2296}
{x=201,m=15,a=1101,s=251}
{x=2374,m=392,a=197,s=1186}
{x=846,m=2019,a=840,s=1984}
{x=1270,m=1337,a=732,s=273}
{x=430,m=1376,a=10,s=1484}
{x=2978,m=1541,a=389,s=32}
{x=291,m=2915,a=3141,s=759}
{x=98,m=223,a=387,s=124}
{x=806,m=1847,a=277,s=2653}
{x=152,m=31,a=2019,s=214}
{x=1327,m=3102,a=637,s=260}
{x=14,m=549,a=1095,s=313}
{x=152,m=3,a=138,s=1768}
{x=803,m=925,a=250,s=2091}
{x=308,m=347,a=643,s=2840}
{x=26,m=161,a=755,s=124}
{x=2561,m=354,a=810,s=839}
{x=445,m=1320,a=359,s=367}
{x=2929,m=673,a=167,s=1894}
{x=212,m=719,a=3037,s=1565}
{x=694,m=275,a=758,s=1092}
{x=1612,m=41,a=119,s=1171}
{x=394,m=87,a=2515,s=137}
{x=53,m=2353,a=1291,s=2904}
{x=3170,m=1480,a=1660,s=2427}
{x=667,m=1771,a=455,s=2370}
{x=2338,m=505,a=2285,s=197}
{x=282,m=325,a=1145,s=596}
{x=3203,m=2041,a=3037,s=861}
{x=785,m=818,a=51,s=2313}
{x=355,m=517,a=32,s=2320}
{x=880,m=474,a=744,s=163}
{x=590,m=958,a=1238,s=2017}
{x=1887,m=452,a=156,s=43}
{x=157,m=1086,a=345,s=22}
{x=314,m=1417,a=1425,s=949}
{x=580,m=316,a=543,s=20}
{x=1270,m=1227,a=239,s=147}
{x=1544,m=307,a=148,s=598}
{x=281,m=33,a=1889,s=1040}
{x=1338,m=474,a=1,s=85}
{x=1119,m=141,a=2187,s=927}
{x=2090,m=395,a=1095,s=48}
{x=1924,m=1593,a=86,s=489}
{x=1149,m=1001,a=72,s=84}
{x=173,m=119,a=254,s=1160}
{x=667,m=708,a=358,s=1177}
{x=187,m=815,a=1244,s=664}
{x=472,m=180,a=923,s=443}
{x=961,m=1136,a=400,s=418}
{x=68,m=2255,a=2883,s=1576}
{x=331,m=185,a=1787,s=1397}
{x=783,m=64,a=123,s=925}
{x=1341,m=15,a=2238,s=265}
{x=796,m=1423,a=97,s=22}
{x=88,m=2065,a=1867,s=1499}
{x=481,m=2118,a=522,s=985}
{x=128,m=31,a=1115,s=1139}
{x=1582,m=832,a=793,s=1821}
{x=730,m=417,a=88,s=2828}
{x=1017,m=525,a=402,s=1384}
{x=735,m=2338,a=358,s=387}
{x=45,m=2976,a=351,s=337}
{x=11,m=914,a=58,s=898}
{x=1168,m=233,a=423,s=1256}
{x=628,m=824,a=186,s=1032}
{x=1019,m=586,a=756,s=475}
{x=1502,m=142,a=138,s=2148}
{x=687,m=2860,a=1046,s=1692}
{x=2432,m=2368,a=458,s=677}
{x=3265,m=797,a=560,s=2373}
{x=1232,m=244,a=365,s=979}
{x=409,m=241,a=25,s=596}
{x=566,m=3236,a=643,s=301}
{x=2605,m=1717,a=2351,s=233}
{x=1214,m=17,a=3358,s=880}
{x=211,m=3266,a=2322,s=329}
{x=164,m=409,a=274,s=70}
{x=165,m=2122,a=642,s=1213}
{x=2546,m=749,a=3016,s=2875}
{x=2331,m=962,a=304,s=2237}
{x=222,m=2772,a=1671,s=33}
{x=464,m=494,a=1402,s=172}
{x=3274,m=123,a=1811,s=796}
{x=537,m=1051,a=1831,s=3086}
{x=85,m=1936,a=1371,s=1794}
{x=98,m=366,a=782,s=3305}
{x=1304,m=724,a=1899,s=294}
{x=1404,m=980,a=1428,s=886}
{x=2017,m=170,a=2827,s=1740}
{x=1057,m=1816,a=2,s=2437}
{x=2526,m=2157,a=3418,s=8}
{x=517,m=46,a=2038,s=28}
{x=20,m=1901,a=3882,s=471}
{x=340,m=1305,a=1753,s=146}
{x=1564,m=633,a=485,s=171}
{x=3053,m=26,a=1201,s=36}
{x=537,m=1415,a=2285,s=742}
{x=157,m=1003,a=44,s=2287}
{x=2280,m=800,a=3070,s=633}
{x=1114,m=1412,a=458,s=1815}
{x=3195,m=2527,a=809,s=2109}
{x=2978,m=743,a=730,s=1140}
{x=443,m=386,a=669,s=217}
{x=352,m=3446,a=1156,s=298}
{x=1285,m=799,a=2483,s=114}
{x=897,m=835,a=2047,s=176}
{x=2213,m=573,a=1741,s=3258}
{x=2621,m=747,a=1566,s=1259}
{x=234,m=459,a=1347,s=78}
{x=60,m=94,a=1007,s=264}
{x=72,m=331,a=459,s=2983}
{x=388,m=1596,a=3322,s=321}
{x=1361,m=398,a=123,s=483}
{x=1755,m=265,a=2042,s=101}
{x=3135,m=1342,a=1262,s=2395}
{x=1262,m=962,a=1971,s=3012}
{x=529,m=2401,a=3341,s=617}
{x=1357,m=2699,a=1840,s=108}
{x=2675,m=1362,a=83,s=343}
{x=85,m=753,a=1820,s=1508}
{x=737,m=1028,a=21,s=116}
{x=24,m=260,a=1871,s=2953}
{x=1501,m=42,a=1765,s=7}
{x=455,m=208,a=399,s=134}
{x=620,m=3048,a=766,s=436}
{x=287,m=168,a=155,s=359}
{x=877,m=268,a=398,s=2263}
{x=274,m=565,a=1250,s=243}
{x=1722,m=1609,a=694,s=1094}
{x=8,m=2653,a=2268,s=1762}
{x=557,m=2514,a=452,s=398}
{x=463,m=675,a=527,s=62}
{x=67,m=367,a=535,s=799}
{x=924,m=204,a=657,s=361}
{x=252,m=466,a=287,s=857}
{x=449,m=273,a=1311,s=848}
{x=6,m=523,a=906,s=838}
{x=1,m=511,a=2647,s=194}
{x=3523,m=319,a=3284,s=1244}
{x=541,m=2025,a=1571,s=2620}
{x=946,m=1065,a=801,s=35}
{x=358,m=121,a=351,s=2824}
{x=18,m=1408,a=57,s=141}
{x=29,m=330,a=5,s=1147}
{x=91,m=257,a=1162,s=243}
{x=222,m=477,a=1089,s=78}
{x=2048,m=1692,a=3643,s=771}
{x=301,m=2792,a=22,s=567}
{x=741,m=310,a=727,s=1519}
{x=293,m=1152,a=2229,s=1121}
{x=6,m=1161,a=60,s=629}
{x=977,m=3522,a=284,s=11}
{x=759,m=1225,a=579,s=2665}
{x=1038,m=1944,a=986,s=130}
{x=2470,m=1253,a=1236,s=1964}
{x=1532,m=1286,a=465,s=78}
{x=621,m=1251,a=1130,s=264}
{x=172,m=136,a=1170,s=1884}
{x=2690,m=714,a=1735,s=1358}
{x=351,m=1116,a=605,s=323}
{x=636,m=2243,a=2326,s=215}
{x=597,m=1687,a=1704,s=313}
{x=857,m=459,a=3229,s=602}
{x=900,m=879,a=1388,s=1478}
{x=27,m=576,a=1162,s=27}
{x=147,m=1606,a=1739,s=892}
{x=913,m=242,a=1129,s=241}
{x=1943,m=368,a=3271,s=465}
{x=27,m=94,a=1237,s=360}
{x=756,m=1656,a=575,s=569}
{x=703,m=1000,a=523,s=2228}
{x=3170,m=962,a=389,s=1720}
{x=1328,m=405,a=109,s=739}
{x=1271,m=1637,a=785,s=2471}";
            var sample = @"px{a<2006:qkq,m>2090:A,rfg}
pv{a>1716:R,A}
lnx{m>1548:A,A}
rfg{s<537:gd,x>2440:R,A}
qs{s>3448:A,lnx}
qkq{x<1416:A,crn}
crn{x>2662:A,R}
in{s<1351:px,qqz}
qqz{s>2770:qs,m<1801:hdj,R}
gd{a>3333:R,R}
hdj{m>838:A,pv}

{x=787,m=2655,a=1222,s=2876}
{x=1679,m=44,a=2067,s=496}
{x=2036,m=264,a=79,s=2244}
{x=2461,m=1339,a=466,s=291}
{x=2127,m=1623,a=2188,s=1013}";

            part1(sample);
            part2(sample);
            part1(input);
            part2(input);
        }
        private static void part1(string input)
        {
            var inputs = input.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).ToArray();
            int count = 0;
            int m = inputs.Length;

            var workflows = new Dictionary<string, Workflow>();
            var parts = new List<Part>();
            for (int i = 0; i < m; i++)
            {
                var line = inputs[i];
                if (line[0] == '{')// it's a part
                    parts.Add(new Part(line));
                else
                {
                    var w = new Workflow(line);
                    workflows[w.name] = w;
                }
            }
            var accepted = new List<Part>();
            foreach (var part in parts)
            {
                string state = "in";
                while (state != "A" && state != "R")
                {
                    var wfw = workflows[state];
                    foreach (var w in wfw.rules)
                    {
                        if (w.predicate(part))
                        {
                            state = w.name;
                            break;
                        }
                    }
                }
                if (state == "A")
                    accepted.Add(part);

            }
            foreach (var part in accepted)
            {
                count += part.x + part.a + part.m + part.s;
            }
            Console.WriteLine($"1st star is {count}");
        }


        private static void part2(string input)
        {
            var inputs = input.Split("\r\n", StringSplitOptions.RemoveEmptyEntries).ToArray();
            long count = 0;
            int m = inputs.Length;
            var workflows = new Dictionary<string, Workflow2>();
            for (int i = 0; i < m; i++)
            {
                var line = inputs[i];
                if (line[0] != '{')// it's a workflow
                {
                    var w = new Workflow2(line);
                    workflows[w.name] = w;
                }
            }
            var accepted = new List<Part2>();
            var rejected = new List<Part2>();
            var q = new Queue<(Part2 p2, string state)>();
            q.Enqueue((new Part2 { amax = 4000, amin = 1, mmax = 4000, mmin = 1, smax = 4000, smin = 1, xmax = 4000, xmin = 1 }, "in"));
            while (q.Count > 0)
            {
                var (part, state) = q.Dequeue();
                if (state == "A")
                {
                    accepted.Add(part);
                    continue;
                }
                if (state == "R")
                {
                    rejected.Add(part);
                    continue;
                }

                var w = workflows[state];
                foreach (var r in w.rules)
                {
                    if (r.limit == int.MinValue) // should be last condition we add the remaining
                    {
                        q.Enqueue((part, r.name));
                        continue;
                    }
                    if (r.v == "a")
                    {
                        if (r.gt)
                        {
                            if (part.amax <= r.limit) continue; // interested in a>limit and amax is less than or equals limit, so next rule
                            if (r.limit < part.amin) // take it all
                            {
                                q.Enqueue((part, r.name)); break; // no more part to split, all has been transfered
                            }
                            var p2 = part.Clone();
                            p2.amin = r.limit + 1; // all that is greater than r.limit
                            q.Enqueue((p2, r.name));
                            part.amax = r.limit; // all that is less than or equals to r.limit continue to the next rule.
                        }
                        else
                        {
                            if (r.limit <= part.amin) continue; // interested in a<limit and amin is greater than or equals limit, so next rule
                            if (part.amax < r.limit) // take it all
                            {
                                q.Enqueue((part, r.name)); break; // no more part to split, all has been transfered
                            }
                            var p2 = part.Clone();
                            p2.amax = r.limit - 1; // all that is greater than r.limit
                            q.Enqueue((p2, r.name));
                            part.amin = r.limit; // all that is less than or equals to r.limit continue to the next rule.
                        }
                    }
                    if (r.v == "s")
                    {
                        if (r.gt)
                        {
                            if (part.smax <= r.limit) continue; // interested in a>limit and amax is less than or equals limit, so next rule
                            if (r.limit < part.smin) // take it all
                            {
                                q.Enqueue((part, r.name)); break; // no more part to split, all has been transfered
                            }
                            var p2 = part.Clone();
                            p2.smin = r.limit + 1; // all that is greater than r.limit
                            q.Enqueue((p2, r.name));
                            part.smax = r.limit; // all that is less than or equals to r.limit continue to the next rule.
                        }
                        else
                        {
                            if (r.limit <= part.smin) continue; // interested in a<limit and amin is greater than or equals limit, so next rule
                            if (part.smax < r.limit) // take it all
                            {
                                q.Enqueue((part, r.name)); break; // no more part to split, all has been transfered
                            }
                            var p2 = part.Clone();
                            p2.smax = r.limit - 1; // all that is greater than r.limit
                            q.Enqueue((p2, r.name));
                            part.smin = r.limit; // all that is less than or equals to r.limit continue to the next rule.
                        }
                    }
                    if (r.v == "x")
                    {
                        if (r.gt)
                        {
                            if (part.xmax <= r.limit) continue; // interested in a>limit and amax is less than or equals limit, so next rule
                            if (r.limit < part.xmin) // take it all
                            {
                                q.Enqueue((part, r.name)); break; // no more part to split, all has been transfered
                            }
                            var p2 = part.Clone();
                            p2.xmin = r.limit + 1; // all that is greater than r.limit
                            q.Enqueue((p2, r.name));
                            part.xmax = r.limit; // all that is less than or equals to r.limit continue to the next rule.
                        }
                        else
                        {
                            if (r.limit <= part.xmin) continue; // interested in a<limit and amin is greater than or equals limit, so next rule
                            if (part.xmax < r.limit) // take it all
                            {
                                q.Enqueue((part, r.name)); break; // no more part to split, all has been transfered
                            }
                            var p2 = part.Clone();
                            p2.xmax = r.limit - 1; // all that is greater than r.limit
                            q.Enqueue((p2, r.name));
                            part.xmin = r.limit; // all that is less than or equals to r.limit continue to the next rule.
                        }
                    }
                    if (r.v == "m")
                    {
                        if (r.gt)
                        {
                            if (part.mmax <= r.limit) continue; // interested in a>limit and amax is less than or equals limit, so next rule
                            if (r.limit < part.mmin) // take it all
                            {
                                q.Enqueue((part, r.name)); break; // no more part to split, all has been transfered
                            }
                            var p2 = part.Clone();
                            p2.mmin = r.limit + 1; // all that is greater than r.limit
                            q.Enqueue((p2, r.name));
                            part.mmax = r.limit; // all that is less than or equals to r.limit continue to the next rule.
                        }
                        else
                        {
                            if (r.limit <= part.mmin) continue; // interested in a<limit and amin is greater than or equals limit, so next rule
                            if (part.mmax < r.limit) // take it all
                            {
                                q.Enqueue((part, r.name)); break; // no more part to split, all has been transfered
                            }
                            var p2 = part.Clone();
                            p2.mmax = r.limit - 1; // all that is greater than r.limit
                            q.Enqueue((p2, r.name));
                            part.mmin = r.limit; // all that is less than or equals to r.limit continue to the next rule.
                        }
                    }
                }
            }
            foreach (var a in accepted)
            {
                count += (a.amax - a.amin + 1) * (a.xmax - a.xmin + 1) * (a.smax - a.smin + 1) * (a.mmax - a.mmin + 1);
            }


            Console.WriteLine($"2nd star is {count}");
            foreach (var a in rejected)
            {
                count += (a.amax - a.amin + 1) * (a.xmax - a.xmin + 1) * (a.smax - a.smin + 1) * (a.mmax - a.mmin + 1);
            }
            Console.WriteLine($"2nd star control is {count}");

        }

    }

    public class Workflow2
    {
        public string name;
        public List<(string v, bool gt, int limit, string name)> rules = new List<(string v, bool gt, int limit, string name)>();
        public Workflow2(string input)
        {
            var line = input.Split(new char[] { '{', '}', ',', ':' }, StringSplitOptions.RemoveEmptyEntries);
            name = line[0];
            int n = line.Length;
            for (int i = 1; i < n - 1; i += 2)
            {
                int limit = int.Parse(line[i][2..]);
                rules.Add((line[i][0..1], line[i][1] == '>', limit, line[i + 1]));
            }

            rules.Add(("s", true, int.MinValue, line[^1]));
        }
    }

    public class Part2
    {
        public Part2 Clone()
        {
            return new Part2() { xmax = this.xmax, xmin = this.xmin, amin = this.amin, amax = this.amax, mmax = this.mmax, mmin = this.mmin, smax = this.smax, smin = this.smin };
        }
        public long xmin, xmax, mmin, mmax, amin, amax, smin, smax;
    }

    public class Workflow
    {
        public string name;
        public List<(Func<Part, bool> predicate, string name)> rules = new List<(Func<Part, bool> predicate, string name)>();
        public Workflow(string input)
        {
            var line = input.Split(new char[] { '{', '}', ',', ':' }, StringSplitOptions.RemoveEmptyEntries);
            name = line[0];
            int n = line.Length;
            for (int i = 1; i < n - 1; i += 2)
            {
                int limit = int.Parse(line[i][2..]);
                switch (line[i][0..2])
                {
                    case "a<": rules.Add(((part => part.a < limit), line[i + 1])); break;
                    case "a>": rules.Add(((part => part.a > limit), line[i + 1])); break;
                    case "x<": rules.Add(((part => part.x < limit), line[i + 1])); break;
                    case "x>": rules.Add(((part => part.x > limit), line[i + 1])); break;
                    case "m<": rules.Add(((part => part.m < limit), line[i + 1])); break;
                    case "m>": rules.Add(((part => part.m > limit), line[i + 1])); break;
                    case "s<": rules.Add(((part => part.s < limit), line[i + 1])); break;
                    case "s>": rules.Add(((part => part.s > limit), line[i + 1])); break;
                }
            }

            rules.Add(((_ => true), line[^1]));
        }
    }

    public class Part
    {
        public int x, m, a, s;
        public Part(string input)
        {
            var tok = input.Split(new char[] { '{', ',', '=', '}' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < tok.Length; i += 2)
            {
                if (tok[i] == "x") x = int.Parse(tok[i + 1]);
                else if (tok[i] == "m") m = int.Parse(tok[i + 1]);
                else if (tok[i] == "a") a = int.Parse(tok[i + 1]);
                else if (tok[i] == "s") s = int.Parse(tok[i + 1]);
            }
        }
    }

}