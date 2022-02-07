# Interfaces Inteligentes. Prototipo de Realidad Virtual.

Marcos Barrios

alu0101056944

## Gif con la ejecución

![nivel1](assets/nivel1_gif.gif)
![nivel2](assets/nivel2_gif.gif)
![nivel3](assets/nivel3_gif.gif)

## Hitos de programación

- Uso de físicas. Relacionado con las prácticas 1 y 2.
- Uso de eventos para la interacción entre Scripts de GameObjects. Relacionado con la práctica 3 de eventos.
- Uso de cámara de realidad virtual.

## Aspectos a destacar

Se emplean las físicas de forma extensiva y una ampliación a interfaces multimodales la convertiría en un juego potencialmente divertido, en concreto el uso de reconocimiento de voz para eliminar objetos en vez de la mecánica de mirar y clickear. También le favorecería una enorme variedad de objetos y localizaciones posibles en las que estén si se trata del puzzle del segundo nivel.

No se han incluido sensores relacionados con interfaces multimodales.

## Consideraciones importantes

Este trabajo ha sido realizado de forma individual.

Al tratarse de un prototipo es conveniente no abusar de las físicas, especialmente cuando se está utilizando la mecánica de agarrar objetos. Adicionalmente, se trata de un juego exigente por lo que es necesario un móvil con capacidades considerables.

## Tareas realizadas

Lo primero que se hizo fue crear un terreno en la primera escena. Tras decorarlo, se creó un modelo de edificio a cielo abierto con una terraza que forma el spawn del jugador al abrir el juego. Un modelo 3D representa un teletransporte que lleva al jugador a la siguiente escena.

En la siguiente escena se modeló el interior de un edificio de temática moderna. La idea es que según se avanza y se pasa a distintos escenarios los puzzles son más complejos y la línea temporal del escenario se acerca cada vez más a la actualidad. En este caso, el segundo escenario consiste en el interior de un edificio de alrededor de 1900, con todos de madera. Se insertó una plataforma a un extremo que lleva al jugador al siguiente escenario.

En el siguiente y último escenario la temática es de un laboratorio más moderno, rozando lo futurista. Es en este escenario donde se introdujo una última salita que contiene la recompensa final del jugador. En dicha sala se importó un modelo de cofre de oro.

Una vez creados todos los escenarios y tras haberlos unido mediante teletransportes, se comenzó a desarrollar los puzzles. Los dos primeros escenarios sirven como tutorial para las mecánicas del último. En el primero hay un cilindro que el jugador debe empujar hacia la placa de presión para poder abrir la puerta hacia la siguiente escena.

En la escena del interior de madera hay muebles y varios objetos escondidos. El jugador debe encontrar todos los objetos y clickearlos para hacerlos desaparecer.

En el último escenario el jugador debe pronunciar los nombres de los objetos que están dentro de unas capsulas. Se desconoce qué es lo que hay dentro por lo que es necesario romper el cristal de las cápsulas empujando esferas hacia ellas. Hay un tiempo límite y unas plataformas móviles dificultan los empujes de las esferas, ya que puede que se queden pegadas las esferas en ellas, lo que implica que el jugador deberá empujarlas fuera de las esferas. Eso hace que el posicionaminto de las esferas se vuelva desfavorable, por lo que el jugador debe aprovechar las mecánicas de agarre para posicionar estratégicamente las esferas. Sin embargo, las esferas pesan, lo que ralentiza el movimiento del jugador, haciendo que pierda más el tiempo. También se introdujo un tubo expendedor de esferas para los casos donde por cualquier circunstancia se pierdan las esferas que están en juego. Una vez identificados y destruidos todos los objetos, el jugador ganará acceso al cofre del tesoro.

Para todo ello fue necesaria la implementación de scripts para agarrar objetos, empujarlos y para que se queden pegados a ciertos <code>GameObject</code>, además de scripts para la activación de las puertas según el nº de objetos en un contenedor, según se active una placa de presión y según el nº de objetos pendientes por descubrir. También se utilizaron scripts para la destrucción de objetos al presionar una tecla.