# Tutorial en beschrijving


## Inleiding

Deze document is gemaakt om uit te leggen hoe het je het spel kan gebruiken en wat het normale proces van het spel is.

Als extra hebben we op laatste van deze document een paar optioneele functies getoont zodat u zelf met deze spel kan spelen om beter onze opdracht te verbeteren.

## Spelverloop, beloning en actieruimte

In deze spel moet de speler (oranje blok) door het obstakel (rode rechthoekig blok) die langzaam naar het speler gaat, springen.

Als het obstakel het speler raakt eindigt het episode en begint het proces opnieuw met een straf aan hun "reward" punten. Maar als de speler door het obstakel kan springen dan krijg de agent een beloning end begint de episode opnieuw.

Om natuurlijk te vermijden dat de speler niet de hele tijd springt, krijgt de speler een kleine beloning als hij de Plane aanraakt.

![level](ReadmeImages/level.jpg)

## Ray perception

![rays](ReadmeImages/Rays.jpg)

## Code

## Componenten

## Configuratie

## Resultaten en conclusie

## Instructies

- Ga naar de &quot;scenes&quot; folder in de asset explorer.

![scenes](ReadmeImages/Scenes.jpg)
- Dubbel klik de &quot;group opdracht&quot; scene.

![opdracht](ReadmeImages/Opdracht.jpg)
- (inference) Druk de start knop op de top van het scherm.
(de brain is al geplaatst op de speler).

![start](ReadmeImages/Start.jpg)

- (hueristic) Selecteer "hueristic only" in de behavior parameters van de speler
om de speler zelf te controleren. (spacebar om het te laten springen).

![behavior](ReadmeImages/Behavior.jpg)


## Optioneel functies
- Klik de EnvSpawner en kies hoeveel enviroments u wilt spawnen door de "total" slider te bewegen.

![total](ReadmeImages/TotalSlider.jpg)
- U kunt de prefabs vinden in de "Prefabs" folder in het asset explorer, daar vind u de enviroment+speler prefab en de obstacle prefab.

![prefabs](ReadmeImages/Prefabs.jpg)
- klik de "scripts" folder om de "eyemover" script te vinden en andere scripts dat we gebruiken zoals (ENV,ObsticleSpawner en Move)

![scripts](ReadmeImages/Scripts.jpg)
- de mover.yaml file kunt u in de learning folder vinden in het asset explorer.

- de Speed attribute van het eye mover script bij de speler controleert de hoogte het jump, verander het als u wilt dat de speler hoger of lager springt.

![Speed](ReadmeImages/Speed.jpg)