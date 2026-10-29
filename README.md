# Super Mario Bros (2D)

Fork del proyecto **SUPER-Mario** de [Jesusbautistah](https://github.com/Jesusbautistah/SUPER-MArio),
ampliado con nuevos niveles, sonido, contadores y un castillo final de diseño propio.

Repositorio: <https://github.com/crlale775/mario-alejandro-acho>

## Mejoras agregadas

- **Escena de menú inicial** con cuatro opciones navegables (nueva partida, nivel
  subterráneo, nivel acuático y castillo). Cualquier opción inicia el juego.
- **Sonido ambiente** con un tema musical distinto por nivel (superficie, caverna,
  fondo marino y castillo), generado por síntesis para no depender de archivos externos.
- **Efectos de sonido** de salto, pisotón, power-up, daño, muerte del personaje,
  moneda, bloque, tubería, hacha y jefe final.
- **Contadores en pantalla**: tiempo restante, puntaje (monedas y enemigos
  eliminados), monedas y vidas. El tiempo restante se bonifica al terminar el nivel.
- **Pantalla de Game Over** al quedarse sin vidas y **pantalla de victoria** al
  derrotar a Bowser.

## Niveles

| Nivel | Contenido |
| ----- | --------- |
| 1-1 | Nivel original del proyecto base |
| 1-2 | Nivel subterráneo, réplica del clásico, con plantas piraña en las tuberías |
| 1-3 | Nivel acuático con nado, corales, bloopers y peces |
| 1-4 | Castillo de Bowser de creación propia |

### Castillo de Bowser (1-4)

El castillo es el nivel más trabajado y se recorre en varias salas:

- Salón de entrada con columnas, antorchas, ventanas y cadenas.
- Foso de lava cruzado con ascensores que el jugador debe tomar en el momento justo.
- Corredor de cañones que disparan balas, con un canal de lava y burbujas (Podoboos).
- Sala de barras de fuego giratorias y plantas piraña.
- **Lago de lava con la montura de Toad**: Toad va encima de una bola de fuego
  gigante que rueda sobre la lava. El jugador se sube y la conduce con
  izquierda/derecha para cruzar el lago.
- Sala de plataformas colgantes sobre lava.
- Puente final: Bowser patrulla y lanza bolas de fuego; al tocar el hacha el
  puente se derrumba, Bowser cae a la lava y Toad queda rescatado.

## Controles

| Acción | Tecla |
| ------ | ----- |
| Moverse | Flechas izquierda / derecha o A / D |
| Saltar (y nadar) | Espacio, Z o flecha arriba |
| Conducir la bola de fuego de Toad | Izquierda / derecha encima de la montura |
| Volver al menú | Esc |

## Ejecutar el proyecto

1. Abrir la carpeta del proyecto con **Unity 6.3** (`6000.3.16f1`).
2. Abrir la escena `Assets/Scenes/Menu.unity` y presionar Play.
3. Para generar el ejecutable: menú **Mario > Compilar para Windows**
   (o `BuildScript.BuildWindows` en modo batch). El resultado queda en `Build/Windows`.

## Notas de la entrega

- **Dificultad principal**: lograr que las plataformas móviles y la bola de fuego
  de Toad transportaran al jugador sin sacarlo de la cámara ni romper la física de
  Unity, y ajustar la altura de cada tramo para que todos los saltos fueran posibles.
- **Característica favorita**: la montura de Toad. Es la única sección donde el
  jugador no controla a Mario sino que conduce una bola de fuego para cruzar la lava.
- Todos los sprites nuevos provienen de los assets originales de *Super Mario Bros*.
