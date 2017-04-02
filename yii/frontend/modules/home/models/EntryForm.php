<?php
namespace frontend\modules\home\models;

use yii\base\Model;
use common\models\User;

class EntryForm extends Model
{
    public $password;
    public $email;

    public function rules()
    {
        return [
            [['password', 'email'], 'required', 'message' => 'Это поле не может быть пустым'],
            ['email', 'email', 'message' => 'Введите настоящий E-mail адресс'],
        ];
    }

    public function login()
    {
        $user = User::findByEmail($this->email);

        if (!$user) {
            $this->addError('E-mail', 'Неправильный логин или пароль');

            return false;
        }

        if ($user->validatePassword($this->password)) {
            $this->addError('E-mail', 'Неправильный логин или пароль');   

            return false;
        }

        return Yii::$app->user->login($user, 3600*24*30);
    }
}