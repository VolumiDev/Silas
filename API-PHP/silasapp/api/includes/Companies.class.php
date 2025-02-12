<?php
// IMPORTANTE, ESTE VA DENTRO DE INCLUDES
require_once('Database.class.php');

// COMPANY
class Company
{

    /**
     * 
     *   Esto me gestiona la entrada de la empresa, desde el back de C# podemos poner el status en false en un inicio durante el registro
     *    hasta que complete los datos del perfil que creamos convenientes o suba su primera oferta, no?
     *   Pero por facilitarnos la vida he pensado que el admin cuando introducea la empresa debería rellenar todos estos datos (que son bastante pocos)
     *   Creo que dijimos que hasta que no pone su "Primera oferta" no se activaba, por si acaso lo dejo así
     */
    public static function createCompanyDetails($id_user, $address, $telephone, $contact, $mobile, $status = 1)
    {
        $database = new Database();
        $conn = $database->getConnection();

        $stmt = $conn->prepare('INSERT INTO companies(id_user, address, telephone, contact, mobile, status)
                                VALUES (:id_user, :address, :telephone, :contact, :mobile, :status)');

        $stmt->bindParam(':id_user', $id_user);
        $stmt->bindParam(':address', $address);
        $stmt->bindParam(':telephone', $telephone);
        $stmt->bindParam(':contact', $contact);
        $stmt->bindParam(':mobile', $mobile);
        $stmt->bindParam(':status', $status);

        $stmt->execute();
    }

    // GET por id para llevar el objeto completo al back y trabajar con todos sus atributos
    public static function getAppliesByUserId($id_user)
    {
        $database = new Database();
        $conn = $database->getConnection();

        $stmt = $conn->prepare('SELECT * FROM companies WHERE id_user = :id_user');
        $stmt->bindParam(':id_user', $id_user);

        $stmt->execute();
        return $stmt->fetchAll(PDO::FETCH_ASSOC);
    }

    // Actualizar en perfil
    public static function updateCompanyDetails($id_user, $address = null, $telephone = null, $contact = null, $mobile = null, $status = null)
    {
        $database = new Database();
        $conn = $database->getConnection();

        // A veces no nos proporcionará todos los parámetros..
        $fields = [];
        $params = [':id_user' => $id_user];

        if ($address !== null) {
            $fields[] = 'address = :address';
            $params[':address'] = $address;
        }
        if ($telephone !== null) {
            $fields[] = 'telephone = :telephone';
            $params[':telephone'] = $telephone;
        }
        if ($contact !== null) {
            $fields[] = 'contact = :contact';
            $params[':contact'] = $contact;
        }
        if ($mobile !== null) {
            $fields[] = 'mobile = :mobile';
            $params[':mobile'] = $mobile;
        }
        if ($status !== null) {
            $fields[] = 'status = :status';
            $params[':status'] = $status;
        }

        if (empty($fields)) {
            return;
        }

        $sql = 'UPDATE companies SET ' . implode(', ', $fields) . ' WHERE id_user = :id_user';
        $stmt = $conn->prepare($sql);

        foreach ($params as $param => $value) {
            $stmt->bindValue($param, $value);
        }

        $stmt->execute();
    }

    // Eliminar empresa es pasar a "inactiva" así no hay que gestionar el borrado de las ofertas (que irían de la mano del borrado de la compañía)
    public static function deactivateCompany($id_user)
    {
        $database = new Database();
        $conn = $database->getConnection();

        $stmt = $conn->prepare('UPDATE companies SET status = 0 WHERE id_user = :id_user');
        $stmt->bindParam(':id_user', $id_user);

        $stmt->execute();
    }

    //A PARTIR DE AQUÍ, FUNCIONES PARA GESTIONAR LLAMADAS A DATOS DE LAS EMPRESAS QUE NO FORMAN PARTE DE SU USUARIO

    /**
     * @return array|null Lista de empresas o null si error.
     */
    public static function listAllCompanies()
    {
        $database = new Database();
        $conn = $database->getConnection();

        $stmt = $conn->prepare('SELECT * FROM companies');
        $stmt->execute();
        return $stmt->fetchAll(PDO::FETCH_ASSOC);
    }


    //METODO GET CON EL QUE RE COGEREMOS TODOS LOS APLIQUE QUE HAY PARA UNA EMPRESA
    public static function getApliesByCompanyId($id_company)
    {
        $database = new Database();
        $conn = $database->getConnection();

        $stmt = $conn->prepare('SELECT *
            from students, offers, students_offers
            WHERE students.id_user = students_offers.id_user AND
            students_offers.id_offer = offers.id
            AND offers.id_company = :id_company');


        $stmt->bindParam(':id_company', $id_company);

        

        $stmt->execute();
        return $stmt->fetchAll(PDO::FETCH_ASSOC);
    }
}
