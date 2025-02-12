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

    public static function createOffer($title, $description, $id_course, $date, $location, $id_company)
{
    try 
    {
        $database = new Database();
        $conn = $database->getConnection();

        $stmt = $conn->prepare('INSERT INTO offers (title, description, id_course, date, location, id_company) 
                                VALUES (:title, :description, :id_course, :date, :location, :id_company)');
                                
        $stmt->bindParam(':title', $title);
        $stmt->bindParam(':description', $description);
        $stmt->bindParam(':id_course', $id_course);
        $stmt->bindParam(':date', $date);
        $stmt->bindParam(':location', $location);
        $stmt->bindParam(':id_company', $id_company);

        if ($stmt->execute()) 
        {
            return ['success' => true, 'message' => 'Offer created successfully'];
        } 
        else 
        {
            return ['success' => false, 'message' => 'Failed to create offer'];
        }
    } 
    catch (Exception $e) 
    {
        return ['success' => false, 'message' => 'Error: ' . $e->getMessage()];
    }
}

}
