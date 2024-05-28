package empaquetaweb.test

import kotlinx.serialization.Serializable

@Serializable
data class Respuesta(
    val texto: String,
    val correcta: Boolean
)
