<?php
namespace frontend\modules\home\models;

use yii\base\Model;
use frontend\models\User;

class SignupForm extends Model
{
    public $email;
    public $password;
    public $passwordRepeat;
    public $role;


    public function rules()
    {
        return [
            ['email', 'filter', 'filter' => 'trim'],
            ['email', 'required', 'message' => 'Это поле не может быть пустым.'],
            ['email', 'email', 'message' => 'Пожалуйста, введите настоящий E-mail адрес.'],
            ['email', 'string', 'max' => 255, 'message' => 'Введите настоящий E-mail адрес.'],
            ['email', 'unique', 'targetClass' => '\common\models\User', 'message' => 'Пользователь с таким E-mail уже зарегистрирован.'],

            ['password', 'string', 'min' => 6,  'message' => 'Длина пароля не менее 6 символов.'],
            ['password', 'required', 'message' => 'Это поле не может быть пустым.'],
            ['passwordRepeat', 'required',  'message' => 'Это поле не может быть пустым.'],
        ];
    }

    public function goSignUp()
    {
        if (!$this->validate()) {
            return null;
        }
        $user = new User();
        $user->email = $this->email;
        $user->setPassword($this->password);
        $user->role_id = 1;
        $user->status = 1;
        $user->created_at = date('Y-m-d H:i:s');
        $user->updated_at = date('Y-m-d H:i:s');


        return $user->save() ? $user : null;
    }
    
    public function validatePasswordRepeat($attribute, $params)
    {
        if ($this->password != $this->passwordRepeat) {
            $this->addError($attribute, 'Пароли не совпадают');
            return false;
        }

        return true;
    }

    public function validateEmail($attribute, $params)
    {
        $user = User::findByEmail($this->email);
        if ($user) {
            $this->addError($attribute, 'Пользователь с таким E-mail уже зарегистрирован');
            return false;
        }

        return true;
    }
}