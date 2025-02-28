// À ajuster selon la structure
import netflixModeles from "../models/netflix.modele.js";

const ListerFilmsParTypesEtTitres = async (req, res) => {
        var filmsTrouvesSelonType;
        var filmsSouhaites = [];
        var recherches = [];

        if (req.params.type_titre == "film" || req.params.type_titre == "serie") {
            var type = req.params.type_titre;
        }
        else {
            res.status(404).json({ 
                erreur: 'Requête invalide',
                message: "Le type " + req.params.type_titre + " est invalide. Veuillez utiliser films ou séries"
             });
        }

        await netflixModeles.GetFilmsTypes(type)
                // Si c'est un succès
                .then((films) => {

                    for(let i = 0; i < 3; i++) { // Je veut seulement les trois premiers termes
                            films.forEach( (row) => {
                               var titreFilm = row.title;

                               if(titreFilm.includes(recherches[i])) {
                                    filmsSouhaites.push = row;
                                }
                            });
                    }
                    
                    

                    if (req.query.recherche) {
                        recherches = req.query.recherche.split(",");
                    }
                    else {
                        recherches[0] = ""
                    }

                    res.status(200).json(filmsSouhaites);
                })
                // S'il y a eu une erreur au niveau de la requête, on retourne un erreur 500 car c'est du serveur que provient l'erreur.
                .catch((erreur) => {
                    console.log('Erreur : ', erreur);
                    res.status(500)
                    res.send({
                        erreur: "Erreur du serveur",
                        code: erreur.sqlState,
                        message: erreur.sqlMessage
                    });
                });

                
};

export {
    ListerFilmsParTypesEtTitres
}