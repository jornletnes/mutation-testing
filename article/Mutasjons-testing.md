## Mutasjons-testing 

Okay, så du har skrevet enhets- og integrasjons-tester for kodebasen din. Dekningen er på 80+ prosent. Du legger til en ny IF-gren i en funksjon som har 100% testdekning, og kjører testene. De er grønne. Testdekningen er fortsatt 100%. Hurra. Du sjøsetter koden din i prod. Alt tryner. Hvordan kan dette skje? Testene var jo 100% grønne! *Er testene mine verdiløse?* tenker du, mens vredens tårer koker på dine skamrøde kinn.

Hvordan kan du vite at testene dine faktisk tester endringen din?

Det er her mutasjons-testing kommer inn.

Mutasjons-testing er en tilnærming som muterer (endrer) produksjonskoden, for deretter å sjekke at testene fanger endringen. Enhver mutasjon kalles en mutant, og målet er at testene skal fange denne mutanten, 

![[Pasted image 20250329132636.png]]


## Hva er det mutasjons-testing forsøker å oppnå?

- Identifisere produksjonskode som ikke er skikkelig testet
- Identifisere hvorvidt testene fanger endringer i produksjonskode eller ei
- Kalkulere et måltall for kvaliteten på produksjonskoden pluss testene (mutation score)

## Hva er en mutasjon?
En mutasjon, eller en mutant, er en kodeendring. Det er i hovedsak tre måter kode kan muteres på:

1. Verdi-mutasjon
Vi endrer en verdi, eksempelvis å sette et tall til et annet.

Opprinnelig:
`int inkrement = 1;`
`int tallA = 1;`
`int tallB = tallA + inkrement;`

Endret:
`int inkrement = -100;`
`int tallA = 1;`
`int tallB = tallA + inkrement;`


2. Operatør-mutasjon
Vi endrer en operatør, eksempelvis å snu en "<" til ">"

Opprinnelig:
`if (inkrement < 0)`
	`tallB = tallA - inkrement`
`else`
    `tallB = tallA + inkrement`

Endret:
`if (inkrement > 0)`
	`tallB = tallA - inkrement`
`else`
    `tallB = tallA + inkrement`

3. Statement mutation
Vi forandrer et statement til et annet, eksempelvis å endre innholdet i en if-branch.

Opprinnelig:
`if (inkrement < 0)`
	`tallB = tallA - inkrement`
`else`
    `tallB = tallA + inkrement`

Endret:
`if (inkrement < 0)`
	`tallB = inkrement * tallA`
`else`
    `tallB = tallA + inkrement`

## Hvordan ser dette ut i praksis?

Jeg har en kodebase med 100% coverage på en gitt funksjon, som vist:

![[Pasted image 20250329130706.png]]

Testen som kjører, og leverer 100% dekningsgrad, ser slik ut:

![[Pasted image 20250329131107.png]]


Her har jeg kjørt <a href="https://stryker-mutator.io/">Stryker.NET</a> mot en av mine kodebaser, og kalkulert mutation score. Jeg får en rapport tilbake, og kan drille meg inn i de røde delene av koden:

![[Pasted image 20250329130928.png]]

Jeg kan se at testene mine ikke fanget mutanten. Løsningen, i dette tilfellet, er å stramme opp testen til å asserte på resultatet av operatøren. Hvis jeg deretter kjører mutasjons-testene igjen, ser jeg at den nye testen fanger denne mutanten. Testene mine er blitt bedre, selv om dekningsgraden er akkurat den samme.

--->
![[Pasted image 20250329131218.png]]
![[Pasted image 20250329131408.png]]

Alle hjerter fryder seg.

## Ulemper

* Mutasjons-testing er ressurs-krevende og tar lang tid.
* Ikke egnet for Black Box testing - du må ha tilgang på kildekoden.
* Mange mutasjoner er komplekse og svært vanskelige å eliminere med gode tester.

## Hvordan installere og kjøre Stryker.NET

https://stryker-mutator.io/docs/stryker-net/getting-started/

En kjapp cutdown som installerer Stryker.NET for alle brukerne på din maskin, kjører mutasjons-testene og fyrer opp en rapport:

```
dotnet tool install -g dotnet-stryker
... cd til repoet ditt
dotnet stryker -o
```


