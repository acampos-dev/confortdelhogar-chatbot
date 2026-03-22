Confort WhatsApp AI Bot

AI-powered WhatsApp assistant for Confort del Hogar.
Automates customer support, recommends products, and integrates with internal systems to increase sales and reduce manual workload.

Overview

This project aims to build an intelligent assistant that interacts with customers via WhatsApp, providing real-time product information and personalized recommendations.

The system connects to the company's internal system (Integra - GeneXus) to retrieve accurate data such as products, prices, and stock.

Objectives
Automate customer support via WhatsApp
Provide real-time product recommendations
Send purchase links directly to users
Reduce manual workload for sales agents
Increase conversion and sales
Architecture
WhatsApp User
     ↓
Twilio API
     ↓
Backend (Node.js / NestJS)
     ↓
OpenAI (Intent detection + response generation)
     ↓
Data Access Layer
     ↓
Integra Database (GeneXus)
Tech Stack
Backend: Node.js + TypeScript
Framework: NestJS (Clean Architecture)
AI: OpenAI
WhatsApp Integration: Twilio API
Database: Integra (GeneXus)
Architecture Style: Clean Architecture
Main Flow
User sends a message via WhatsApp
Twilio forwards the message to the backend (webhook)
The system processes the message
OpenAI detects user intent
Backend queries the database
AI generates a response
Response is sent back to the user
MVP Scope

Initial version will support:

Product search
Automated responses with:
Product name
Price
Purchase link
Future Improvements
Order tracking
Shopping cart via WhatsApp
Personalized promotions
Customer segmentation
Sales analytics
Integration Requirements (Integra)

The system requires read-only access to the database.

Required data:

Products
Prices
Stock
Categories
Important Notes
The AI does not access the database directly
All business logic is handled in the backend
Responses must be based on real data
Environment Variables

Create a .env file based on:

PORT=3000

OPENAI_API_KEY=

TWILIO_ACCOUNT_SID=
TWILIO_AUTH_TOKEN=
TWILIO_WHATSAPP_NUMBER=

DB_HOST=
DB_USER=
DB_PASS=
DB_NAME=

Author

Internal project for Confort del Hogar.
