User Claim-Based Authorization in ASP.NET Core 4.8

This project demonstrates how to implement claim-based authorization in an ASP.NET Core 4.8 application.
It includes both controller-based authorization and a custom action filter, allowing flexible access control based on user claims.

✨ Features

Uses claims to authorize users.

Controller-level claim checks via policies.

Custom Action Filter for dynamic claim validation.

Easy to extend and maintain.

⚙️ How It Works

Claims Assignment
When a user logs in, specific claims (like permissions or roles) are issued and attached to their identity.

Controller-Level Authorization
Predefined policies check user claims before granting access to controllers or actions.

Best for static and reusable claim rules.

Custom Action Filter
A reusable filter checks claims dynamically at the action level.

Best for fine-grained or context-specific checks.

🏗 Project Structure

Controllers: Demonstrates authorization applied at controller and action levels.

Action Filter: Provides claim validation logic.

Startup Configuration: Defines policies and integrates authorization.

✅ Summary

Policies are ideal for static, reusable checks.

Action Filters are ideal for flexible, action-specific checks.

Together, they provide a powerful claim-based authorization system in ASP.NET Core 4.8.
