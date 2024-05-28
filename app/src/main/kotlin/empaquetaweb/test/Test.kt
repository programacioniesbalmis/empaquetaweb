package empaquetaweb.test

import kotlinx.serialization.Serializable

@Serializable
data class Test(
    val nombre: String,
    val preguntas: List<Pregunta>
)
