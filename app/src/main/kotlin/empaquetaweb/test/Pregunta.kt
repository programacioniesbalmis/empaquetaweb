package empaquetaweb.test

import kotlinx.serialization.Serializable

@Serializable
data class Pregunta(
    val texto: String,
    val respuestas: List<Respuesta>
)
