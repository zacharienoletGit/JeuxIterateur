import express from 'express';
// Importer le fichier de router du fichier sautations.route
import netflixRouter from './src/routes/netflix.routes.js'; // Par exemple, pour un dossier parent

// Créer une application express
const app = express();

// Importer les middlewares
app.use(express.json());

// On associe la route  au router importé
app.use('/api/titres', netflixRouter);

// Middleware pour gérer les routes non définies (404)
app.use((req, res) => {
    const errorMessage = {
      message: `La route ${req.originalUrl} n'est pas définie.`
    };
  
    res.status(404).json(errorMessage);  // Réponse 404 en JSON
});

// Démarrer le serveur
const PORT = process.env.PORT || 3000;
app.listen(PORT, () => {
    console.log(`Serveur démarré sur le port ${PORT}`);
});
