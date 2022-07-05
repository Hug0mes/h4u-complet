<?php 
namespace App\Http\Controllers;

use Illuminate\Http\Request;
use  App\Models\User;

//import auth facades
use Illuminate\Support\Facades\Auth;

class AuthController extends Controller
{
    /**
     * Store a new user.
     *
     * @param  Request  $request
     * @return Response
     */
    public function register(Request $request)
    {
        //validate incoming request 
        $this->validate($request, [
            'Nome' => 'required|string',
            'Email' => 'required|email|unique:users',
            'Password' => 'required',
            'Dtn' => 'required',
            'Genero' => 'required',    
        ]);

        try {
         
            $user = new User;
            $user->Nome = $request->input('Nome');
            $user->Dtn = $request->input('Dtn');
            $user->Regiao = $request->input('Regiao');
            $user->Email = $request->input('Email');
            $user->Genero = $request->input('Genero');
            /*$plainPassword */  $user->Password = $request->input('Password');
            $user->Morada = $request->input('Morada');
            $user->Codigo_Postal = $request->input('Codigo_Postal');
            $user->Estado = $request->input('Estado');
            $user->Interesses = $request->input('Interesses');
            //$user->Password = app('hash')->make($plainPassword);

            $user->save();
            //return successful response
            return response()->json(['user' => $user, 'message' => 'CREATED'], 201);

        } catch (\Exception $e) {
            //return error message
            return response()->json(['message' => 'User Registration Failed!' .$e], 409 );
        }

    }


    /**
     * Get a JWT via given credentials.
     *
     * @param  Request  $request
     * @return Response
     */
    public function login(Request $request)
    {
          //validate incoming request 
        $this->validate($request, [
            'email' => 'required|string',
            'password' => 'required|string',
        ]);

        $credentials = $request->only(['email', 'password']);

        if (! $token = Auth::attempt($credentials)) {
            return response()->json(['message' => 'Unauthorized'], 401);
        }

        return $this->respondWithToken($token);
    }

    public function AtualizarCampo(Request $request) {
        $campo = $request->campo;
        $valor = $request->valor;
        $id = $request->id;
        $user = User::findOrFail($id);

        $user->$campo = $valor;
    }

}