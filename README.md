# Confort WhatsApp AI Bot

Asistente inteligente para automatizar consultas comerciales por WhatsApp, recomendar productos y facilitar el acceso a información actualizada de precios y stock.

> **Estado actual:** diseño técnico y preparación del MVP. La integración completa con WhatsApp, IA y el sistema interno todavía está en desarrollo.

## Problema que busca resolver

La atención comercial recibe consultas repetitivas sobre productos, precios, disponibilidad y enlaces de compra. El proyecto busca reducir ese trabajo manual y ofrecer respuestas rápidas basadas en información real de la empresa.

## Alcance del MVP

- Recibir consultas mediante WhatsApp.
- Detectar la intención del cliente.
- Buscar productos por nombre o categoría.
- Consultar precio y disponibilidad.
- Recomendar opciones relevantes.
- Enviar el enlace del producto en la tienda.
- Derivar la conversación a una persona cuando sea necesario.

## Arquitectura propuesta

1. El cliente envía un mensaje por WhatsApp.
2. Twilio reenvía el mensaje al backend mediante un webhook.
3. El backend identifica la intención y valida la solicitud.
4. La capa de acceso a datos consulta la información autorizada.
5. OpenAI ayuda a generar una respuesta basada únicamente en esos datos.
6. Twilio entrega la respuesta al cliente.

## Tecnologías previstas

| Área | Tecnología |
|---|---|
| Backend | Node.js, TypeScript y NestJS |
| Arquitectura | Clean Architecture |
| Inteligencia artificial | OpenAI API |
| Canal de mensajería | Twilio WhatsApp API |
| Datos | Integración de solo lectura con el sistema Integra/GeneXus |

## Principios de diseño

- La IA no accede directamente a la base de datos.
- Las respuestas sobre productos deben basarse en datos reales.
- La lógica de negocio permanece en el backend.
- Las credenciales y secretos se administran mediante variables de entorno.
- La integración con el sistema interno utiliza permisos mínimos y acceso de solo lectura.

## Configuración prevista

La aplicación requerirá variables de entorno para el puerto, OpenAI, Twilio y la conexión de solo lectura a los datos. Los valores reales no deben subirse al repositorio.

## Próximas etapas

- Crear la base del proyecto en NestJS.
- Implementar el webhook de WhatsApp.
- Definir la fuente autorizada de productos, precios y stock.
- Incorporar búsqueda y recomendación de productos.
- Agregar derivación a atención humana.
- Registrar métricas de consultas y conversiones.

## Objetivo

Construir una solución aplicable a un negocio real que combine automatización, integración de sistemas e inteligencia artificial para mejorar la atención y apoyar las ventas.
