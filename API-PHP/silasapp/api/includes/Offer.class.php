<?php
require_once('Database.class.php');

class Offer
{
    /**
     * devuelve todas las ofertas de una empresa dada por su id_company
     * podemos filtrar el campo status pero no creo que sea necesario pq si la compañía no está activa no puede subir oferta
     */
    public static function listOffersByCompanyId($id_company)
    {
        $database = new Database();
        $conn = $database->getConnection();

        //WHERE id_company=:id_company AND status=1 si fuese necesario
        $stmt = $conn->prepare('SELECT id, title, description, id_course, date, location, id_company
                                FROM offers
                                WHERE id_company = :id_company');
        $stmt->bindParam(':id_company', $id_company);
        $stmt->execute();

        return $stmt->fetchAll(PDO::FETCH_ASSOC);
    }
}
