
## Técnica A

Para crear el scroll infinito, agrupamos las tres capas de tilemap (cielo, suelo, árboles) dentro de un objeto vacío llamado ContenedorFondo_A y creamos un duplicado idéntico llamado ContenedorFondo_B. Determinamos que el ancho del mapa (anchoTilemap) era de 20 unidades. Luego, creamos un objeto vacío ControladorFondo al que le añadimos un script. Este script se encarga de mover ContenedorFondo_A y ContenedorFondo_B hacia la izquierda en cada frame. Cuando el primero sale de la pantalla, lo "teletransporta" a la derecha del segundo e intercambia sus roles, creando así la ilusión de un fondo que nunca termina.


El script ScrollFondoTilemap gestiona el movimiento infinito de los dos fondos. En la función Start(), primero se guarda la posición inicial del fondoActual (A) y se coloca al fondoAuxiliar (B) justo a su derecha, usando el anchoTilemap como distancia. Luego, en la función Update(), se mueven ambos fondos hacia la izquierda constantemente. La lógica principal se basa en una comprobación: si el fondoActual (A) se ha movido su ancho completo y ya está saliendo de la cámara, el script lo reposiciona a la derecha del fondoAuxiliar (B) e intercambia sus papeles, convirtiendo a B en el nuevo fondoActual y a A en el nuevo fondoAuxiliar.


![Gif](Imagenes/TA.gif)


## Técnica B

En esta actividad se implementó un sistema de scroll infinito utilizando la Técnica B, donde la cámara sigue al jugador y el fondo, aunque estático, se reposiciona inteligentemente. Para lograrlo, se configuraron dos fondos idénticos (fondoActual y fondoAuxiliar) y se determinó que su ancho (spriteWidth) era de 20 unidades. En la función Start(), el script primero obtiene la referencia de la Camera y calcula el semi-ancho de su encuadre (cameraWidth) usando la fórmula teórica camera.orthographicSize * camera.aspect. Luego, posiciona el fondoAuxiliar a la derecha del fondoActual.

La lógica principal se ejecuta en LateUpdate() (para evitar el parpadeo que ocurría en Update()), donde se comprueba en cada frame la condición exacta de la teoría: pos_camera_x + cameraWidth > pos_fondoA_x + (spriteWidth / 2f). Cuando el borde derecho de la cámara (pos_camera_x + cameraWidth) supera el punto medio del fondo actual, el script teletransporta el fondoActual (que se quedó atrás) a la derecha del fondoAuxiliar e intercambia sus roles usando una variable temp, asegurando así la continuidad infinita del escenario.

Al poner el fondo necesitamos que la cámara tenga un background type uninitialized, pero este produce un parpadeo amarillo por defecto en Unity. Para arreglarlo, busqué en foros de Unity y la solución consiste en Project Settings > Graphics y activar el Render Graph Compatibility Mode.

![Gif](Imagenes/TB.gif)


## Textura: Desplazamiento de Textura

En este ejercicio se aplicó la técnica de desplazamiento de textura (texture scrolling) para crear un fondo que se mueve de forma continua en la escena. Primero se importó una textura configurando su Wrap Mode en Repeat, lo que permite que la imagen se repita sin cortes al desplazarse. Luego, se asignó esa textura a un material con un shader tipo Unlit/Texture, y dicho material se aplicó a un objeto (como un Quad) que actúa como fondo.

Mediante un script en C#, se modificó dinámicamente la propiedad mainTextureOffset del material, incrementando un valor de desplazamiento (offset) en función del tiempo (Time.deltaTime) y una velocidad (scrollSpeed), consiguiendo así el efecto visual de movimiento continuo en el fondo del juego.

Se usa un Quad en lugar de un Sprite 2D porque el Quad es un objeto 3D con un Mesh Renderer, lo que permite trabajar directamente con materiales y texturas estándar de Unity. Estos materiales soportan propiedades como mainTextureOffset o SetTextureOffset, necesarias para desplazar la textura y crear el efecto de fondo en movimiento. En cambio, los Sprites 2D usan un Sprite Renderer y un shader especial que no admite modificar el desplazamiento de la textura ni repetirla de forma automática (a menos que se use un shader personalizado). Por eso, en este tipo de ejercicios donde se manipula el material y su textura, el Quad es la opción correcta: es más flexible, compatible con los shaders de textura y permite el efecto de desplazamiento fácilmente sin configuraciones adicionales.

![Gif](Imagenes/TC.gif)
![Gif](Imagenes/T_Esfera.gif)

## Parallax A: Técnica de Scroll (Doble Controlador)

En esta actividad se implementó un efecto de parallax para simular profundidad, logrando que las capas cercanas se muevan más rápido que las lejanas. Para ello, se separaron las capas de 'azul' (fondo) y 'decorativos' (árboles) en sus propios Grid independientes. Se crearon dos pares de contenedores (A y B) para cada capa y dos controladores (Controlador_Azul y Controlador_Decorativos). A ambos controladores se les aplicó el mismo script de scroll (Técnica A), pero al Controlador_Azul se le asignó una velocidadScroll baja (ej. 1) y al Controlador_Decorativos una velocidad alta (ej. 5), creando así el efecto de profundidad.

La diferencia clave entre este código y el script original del primer ejercicio es la condición de intercambio en la función Update(). El script original usaba if (fondoActual.position.x < posxini - (spriteWidth / 2f)), lo que provocaba un "hueco" o parpadeo porque el intercambio ocurría demasiado pronto (al moverse medio ancho). El código corregido usa if (fondoActual.position.x <= posxini - spriteWidth), esperando a que el fondo se mueva su ancho completo antes de intercambiarlo. Esta corrección elimina el hueco y asegura que el fondoAuxiliar esté en la posición exacta, creando un bucle perfecto y sin parpadeos.

![Gif](Imagenes/PA.gif)

## Parallax B: Técnica de Desplazamiento de Textura

En esta actividad se implementó un efecto de parallax utilizando la técnica de desplazamiento de textura (mainTextureOffset). Para ello, se usaron dos objetos Quad (lienzos 3D planos) en lugar de tilemaps. El Quad_Azul se colocó más lejos (ej. Z=10) y se le asignó un Material (Unlit) con la imagen del cielo (Wrap Mode = Repeat). El Quad_Decorativos se colocó más cerca (ej. Z=5) y usó un material Unlit/Transparent con la imagen de los árboles (guardada como PNG con fondo transparente) para que el cielo se viera a través.

Finalmente, se añadió el mismo script ScrollTexturaOffset a ambos Quads, pero asignando una scrollSpeed baja al Quad_Azul y una más alta al Quad_Decorativos, logrando que la capa de árboles se mueva más rápido que el fondo.

![Gif](Imagenes/PB.gif)