// À ajuster selon la structure
import db from '../config/db.js';

const GetFilmsTypes = (type_titre) => {
    return new Promise((resolve, reject) => {
        if (type_titre = "film") {
            type_titre = "Movie";
        }
        else if (type_titre = "serie") {
            type_titre = "TV Show";
        }

        const requete = `SELECT * FROM netflix_titles WHERE show_type = ?`;

        db.query(requete, type_titre, (erreur, resultat) => {
            if (erreur) {
                // S'il y a une erreur, je la retourne avec reject()
                reject(erreur);
            }
            // Sinon je retourne le résultat sans faire de validation, c'est possible que le résultat soit vide
            resolve(resultat);
        });
    });
};

export default {
    GetFilmsTypes
}