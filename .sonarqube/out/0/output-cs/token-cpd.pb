Û
HD:\Sdk\CodeDesignPlus.Core\src\CodeDesignPlus.Core\Abstractions\IBase.cs
	namespace 	
CodeDesignPlus
 
. 
Core 
. 
Abstractions *
{ 
public 

	interface 
IBase 
{ 
} 
public 

	interface 
IBase 
< 
TKey 
,  
TUserKey! )
>) *
{ 
public 
TKey 
Id 
{ 
get 
; 
set !
;! "
}# $
public 
bool 
State 
{ 
get 
;  
set! $
;$ %
}& '
public 
TUserKey 
IdUserCreator %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
public   
DateTime   
DateCreated   #
{  $ %
get  & )
;  ) *
set  + .
;  . /
}  0 1
}!! 
}"" ³
KD:\Sdk\CodeDesignPlus.Core\src\CodeDesignPlus.Core\Abstractions\IDtoBase.cs
	namespace 	
CodeDesignPlus
 
. 
Core 
. 
Abstractions *
{ 
public 

	interface 
IDtoBase 
: 
IBase  %
{& '
}( )
public 

	interface 
IDtoBase 
< 
TKey "
," #
TUserKey$ ,
>, -
:. /
IBase0 5
<5 6
TKey6 :
,: ;
TUserKey< D
>D E
,E F
IDtoBaseG O
{ 
} 
} ô
ND:\Sdk\CodeDesignPlus.Core\src\CodeDesignPlus.Core\Abstractions\IDtoInteger.cs
	namespace 	
CodeDesignPlus
 
. 
Core 
. 
Abstractions *
{ 
public 

	interface 
IDtoInteger  
<  !
TUserKey! )
>) *
:+ ,
IDtoBase- 5
<5 6
int6 9
,9 :
TUserKey; C
>C D
{ 
}

 
} ï
KD:\Sdk\CodeDesignPlus.Core\src\CodeDesignPlus.Core\Abstractions\IDtoLong.cs
	namespace 	
CodeDesignPlus
 
. 
Core 
. 
Abstractions *
{ 
public 

	interface 
IDtoLong 
< 
TUserKey &
>& '
:( )
IDtoBase* 2
<2 3
long3 7
,7 8
TUserKey9 A
>A B
{ 
}

 
} ¿
ND:\Sdk\CodeDesignPlus.Core\src\CodeDesignPlus.Core\Abstractions\IEntityBase.cs
	namespace 	
CodeDesignPlus
 
. 
Core 
. 
Abstractions *
{ 
public 

	interface 
IEntityBase  
:! "
IBase# (
{) *
}+ ,
public 

	interface 
IEntityBase  
<  !
TKey! %
,% &
TUserKey' /
>/ 0
:1 2
IBase3 8
<8 9
TKey9 =
,= >
TUserKey? G
>G H
,H I
IEntityBaseJ U
{ 
} 
} ý
QD:\Sdk\CodeDesignPlus.Core\src\CodeDesignPlus.Core\Abstractions\IEntityInteger.cs
	namespace 	
CodeDesignPlus
 
. 
Core 
. 
Abstractions *
{ 
public 

	interface 
IEntityInteger #
<# $
TUserKey$ ,
>, -
:. /
IEntityBase0 ;
<; <
int< ?
,? @
TUserKeyA I
>I J
{ 
}

 
} ø
ND:\Sdk\CodeDesignPlus.Core\src\CodeDesignPlus.Core\Abstractions\IEntityLong.cs
	namespace 	
CodeDesignPlus
 
. 
Core 
. 
Abstractions *
{ 
public 

	interface 
IEntityLong  
<  !
TUserKey! )
>) *
:+ ,
IEntityBase- 8
<8 9
long9 =
,= >
TUserKey? G
>G H
{ 
}

 
} ¤
SD:\Sdk\CodeDesignPlus.Core\src\CodeDesignPlus.Core\Abstractions\IStartupServices.cs
	namespace 	
CodeDesignPlus
 
. 
Core 
. 
Abstractions *
{ 
public		 

	interface		 
IStartupServices		 %
{

 
void 

Initialize 
( 
IServiceCollection *
services+ 3
,3 4
IConfiguration5 C
configurationD Q
)Q R
;R S
} 
} ‡<
HD:\Sdk\CodeDesignPlus.Core\src\CodeDesignPlus.Core\Models\Pager\Pager.cs
	namespace 	
CodeDesignPlus
 
. 
Core 
. 
Models $
.$ %
Pager% *
{ 
public 

class 
Pager 
< 
T 
> 
where 
T  !
:" #
IBase$ )
{ 
public 
int 

TotalItems 
{ 
get  #
;# $
private% ,
set- 0
;0 1
}2 3
public 
int 
CurrentPage 
{  
get! $
;$ %
private& -
set. 1
;1 2
}3 4
public 
int 
PageSize 
{ 
get !
;! "
private# *
set+ .
;. /
}0 1
public 
int 

TotalPages 
{ 
get  #
;# $
private% ,
set- 0
;0 1
}2 3
public"" 
int"" 
	StartPage"" 
{"" 
get"" "
;""" #
private""$ +
set"", /
;""/ 0
}""1 2
public&& 
int&& 
EndPage&& 
{&& 
get&&  
;&&  !
private&&" )
set&&* -
;&&- .
}&&/ 0
public** 
int** 

StartIndex** 
{** 
get**  #
;**# $
private**% ,
set**- 0
;**0 1
}**2 3
public.. 
int.. 
EndIndex.. 
{.. 
get.. !
;..! "
private..# *
set..+ .
;... /
}..0 1
public22 
IEnumerable22 
<22 
int22 
>22 
Pages22  %
{22& '
get22( +
;22+ ,
private22- 4
set225 8
;228 9
}22: ;
public66 
List66 
<66 
T66 
>66 
Data66 
{66 
get66 !
;66! "
private66# *
set66+ .
;66. /
}660 1
public?? 
Pager?? 
(?? 
int?? 

totalItems?? #
,??# $
List??% )
<??) *
T??* +
>??+ ,
data??- 1
,??1 2
int??3 6
currentPage??7 B
=??C D
$num??E F
,??F G
int??H K
pageSize??L T
=??U V
$num??W Y
,??Y Z
int??[ ^
maxPages??_ g
=??h i
$num??j l
)??l m
{@@ 	
varBB 

totalPagesBB 
=BB 
(BB 
intBB !
)BB! "
MathBB" &
.BB& '
CeilingBB' .
(BB. /
(BB/ 0
decimalBB0 7
)BB7 8

totalItemsBB8 B
/BBC D
(BBE F
decimalBBF M
)BBM N
pageSizeBBN V
)BBV W
;BBW X
ifEE 
(EE 
currentPageEE 
<EE 
$numEE 
)EE  
currentPageFF 
=FF 
$numFF 
;FF  
elseGG 
ifGG 
(GG 
currentPageGG  
>GG! "

totalPagesGG# -
)GG- .
currentPageHH 
=HH 

totalPagesHH (
;HH( )
intJJ 
	startPageJJ 
,JJ 
endPageJJ "
;JJ" #
ifKK 
(KK 

totalPagesKK 
<=KK 
maxPagesKK &
)KK& '
{LL 
	startPageNN 
=NN 
$numNN 
;NN 
endPageOO 
=OO 

totalPagesOO $
;OO$ %
}PP 
elseQQ 
{RR 
varTT %
maxPagesBeforeCurrentPageTT -
=TT. /
(TT0 1
intTT1 4
)TT4 5
MathTT5 9
.TT9 :
FloorTT: ?
(TT? @
(TT@ A
decimalTTA H
)TTH I
maxPagesTTI Q
/TTR S
(TTT U
decimalTTU \
)TT\ ]
$numTT] ^
)TT^ _
;TT_ `
varUU $
maxPagesAfterCurrentPageUU ,
=UU- .
(UU/ 0
intUU0 3
)UU3 4
MathUU4 8
.UU8 9
CeilingUU9 @
(UU@ A
(UUA B
decimalUUB I
)UUI J
maxPagesUUJ R
/UUS T
(UUU V
decimalUUV ]
)UU] ^
$numUU^ _
)UU_ `
-UUa b
$numUUc d
;UUd e
ifVV 
(VV 
currentPageVV 
<=VV  "%
maxPagesBeforeCurrentPageVV# <
)VV< =
{WW 
	startPageYY 
=YY 
$numYY  !
;YY! "
endPageZZ 
=ZZ 
maxPagesZZ &
;ZZ& '
}[[ 
else\\ 
if\\ 
(\\ 
currentPage\\ $
+\\% &$
maxPagesAfterCurrentPage\\' ?
>=\\@ B

totalPages\\C M
)\\M N
{]] 
	startPage__ 
=__ 

totalPages__  *
-__+ ,
maxPages__- 5
+__6 7
$num__8 9
;__9 :
endPage`` 
=`` 

totalPages`` (
;``( )
}aa 
elsebb 
{cc 
	startPageee 
=ee 
currentPageee  +
-ee, -%
maxPagesBeforeCurrentPageee. G
;eeG H
endPageff 
=ff 
currentPageff )
+ff* +$
maxPagesAfterCurrentPageff, D
;ffD E
}gg 
}hh 
varkk 

startIndexkk 
=kk 
(kk 
currentPagekk )
-kk* +
$numkk, -
)kk- .
*kk/ 0
pageSizekk1 9
;kk9 :
varll 
endIndexll 
=ll 
Mathll 
.ll  
Minll  #
(ll# $

startIndexll$ .
+ll/ 0
pageSizell1 9
-ll: ;
$numll< =
,ll= >

totalItemsll? I
-llJ K
$numllL M
)llM N
;llN O
varoo 
pagesoo 
=oo 

Enumerableoo "
.oo" #
Rangeoo# (
(oo( )
	startPageoo) 2
,oo2 3
(oo4 5
endPageoo5 <
+oo= >
$numoo? @
)oo@ A
-ooB C
	startPageooD M
)ooM N
;ooN O
thisrr 
.rr 

TotalItemsrr 
=rr 

totalItemsrr (
;rr( )
thisss 
.ss 
CurrentPagess 
=ss 
currentPagess *
;ss* +
thistt 
.tt 
PageSizett 
=tt 
pageSizett $
;tt$ %
thisuu 
.uu 

TotalPagesuu 
=uu 

totalPagesuu (
;uu( )
thisvv 
.vv 
	StartPagevv 
=vv 
	startPagevv &
;vv& '
thisww 
.ww 
EndPageww 
=ww 
endPageww "
;ww" #
thisxx 
.xx 

StartIndexxx 
=xx 

startIndexxx (
;xx( )
thisyy 
.yy 
EndIndexyy 
=yy 
endIndexyy $
;yy$ %
thiszz 
.zz 
Pageszz 
=zz 
pageszz 
;zz 
this{{ 
.{{ 
Data{{ 
={{ 
data{{ 
;{{ 
}|| 	
}}} 
}~~ ú
MD:\Sdk\CodeDesignPlus.Core\src\CodeDesignPlus.Core\Models\Pager\Parameters.cs
	namespace 	
CodeDesignPlus
 
. 
Core 
. 
Models $
.$ %
Pager% *
{ 
public 

class 

Parameters 
{		 
[ 	
Range	 
( 
$num 
, 
int 
. 
MaxValue 
, 
ErrorMessage  ,
=- .
$str/ L
)L M
]M N
public 
int 
CurrentPage 
{  
get! $
;$ %
set& )
;) *
}+ ,
[ 	
Range	 
( 
$num 
, 
int 
. 
MaxValue 
, 
ErrorMessage  ,
=- .
$str/ L
)L M
]M N
public 
int 
PageSize 
{ 
get !
;! "
set# &
;& '
}( )
[ 	
Range	 
( 
$num 
, 
int 
. 
MaxValue 
, 
ErrorMessage  ,
=- .
$str/ L
)L M
]M N
public 
int 
MaxPage 
{ 
get  
;  !
set" %
;% &
}' (
} 
} 